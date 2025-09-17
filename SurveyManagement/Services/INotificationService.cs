namespace SurveyManagement.Services;

public interface INotificationService
{
    Task SendNewPollsNotification(int? pollId = null);
}
