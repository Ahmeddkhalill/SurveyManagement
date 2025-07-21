namespace SurveyManagement.Contracts.Polls;

public record PollRequest(
        string Title,
        string Summary,
        bool IsPublished,
        DateTime StartsAt,
        DateTime EndsAt
    );