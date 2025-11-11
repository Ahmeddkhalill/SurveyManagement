using Microsoft.AspNetCore.Identity.UI.Services;
using SurveyManagement.Helpers;

namespace SurveyManagement.Services;

public class NotificationService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IEmailSender emailSender) : INotificationService
{
    private readonly ApplicationDbContext _context = context;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IEmailSender _emailSender = emailSender;

    public async Task SendNewPollsNotification(int? pollId = null)
    {
        IEnumerable<Poll> polls = [];

        if (pollId.HasValue)
        {
            var poll = await _context.Polls
                .SingleOrDefaultAsync(p => p.Id == pollId && p.IsPublished);

            polls = [poll!];
        }
        else
        {
            polls = await _context.Polls
                .Where(p => p.IsPublished && p.StartsAt == DateTime.UtcNow)
                .AsNoTracking()
                .ToListAsync();
        }

        var users = await _userManager.GetUsersInRoleAsync(DefaultRoles.Member);

        var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin;

        foreach (var poll in polls)
        {
            foreach (var user in users)
            {
                var placeHolders = new Dictionary<string, string>
                {
                    { "{{name}}", user.FirstName },
                    { "{{pollTill}}", poll.Title },
                    { "{{endDate}}", poll.EndsAt.ToString() },
                    { "{{url}}", $"{origin}/polls/start/{poll.Id}" }
                };

                var body = EmailBodyBuilder.GenerateEmailBody("PollNotification", placeHolders);

                await _emailSender.SendEmailAsync(user.Email!, $"📣 Survey Management: New Poll - {poll.Title}", body);
            }
        }
    }
}
