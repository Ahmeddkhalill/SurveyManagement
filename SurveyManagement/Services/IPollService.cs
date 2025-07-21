namespace SurveyManagement.Services;

public interface IPollService
{
    Task<IEnumerable<Poll>> GetAllAsync();
    Task<Poll?> GetAsync(int id);
    Task<Poll> AddAsync(Poll poll);
    Task<bool> UpdateAsync(int id, Poll poll);
    Task<bool> DeleteAsync(int id);
    Task<bool> TogglePublishStatusAsync(int id);
}
