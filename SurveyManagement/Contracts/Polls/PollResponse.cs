namespace SurveyManagement.Contracts.Polls;

public record PollResponse(
    int Id,
    string Title,
    string Summary,
    bool IsPublished,
    DateTime StartsAt,
    DateTime EndsAt
);
