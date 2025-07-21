using System.Threading;

namespace SurveyManagement.Services;

public class PollService(ApplicationDbContext context) : IPollService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Poll>> GetAllAsync() => 
        await _context.Polls.AsNoTracking().ToListAsync();

    public async Task<Poll?> GetAsync(int id) => 
        await _context.Polls.FindAsync(id);

    public async Task<Poll> AddAsync(Poll poll)
    {
        await _context.Polls.AddAsync(poll);
        await _context.SaveChangesAsync();

        return poll;
    }

    public async Task<bool> UpdateAsync(int id, Poll poll)
    {
        var currentPoll = await GetAsync(id);

        if (currentPoll is null)
            return false;

        currentPoll.Title = poll.Title;
        currentPoll.Summary = poll.Summary;
        currentPoll.StartsAt = poll.StartsAt;
        currentPoll.EndsAt = poll.EndsAt;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var poll =await GetAsync(id);

        if (poll is null)
            return false;

        _context.Remove(poll);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> TogglePublishStatusAsync(int id)
    {
        var poll = await GetAsync(id);

        if (poll is null)
            return false;

        poll.IsPublished = !poll.IsPublished;

        await _context.SaveChangesAsync();

        return true;
    }
}
