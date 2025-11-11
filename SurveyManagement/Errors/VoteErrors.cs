namespace SurveyManagement.Errors;

public static class VoteErrors
{
    public static readonly Error DuplicatedVote =
        new("Vote.DuplicatedVote", "You have already voted in this poll.", StatusCodes.Status409Conflict);

    public static readonly Error InvalidQuestions =
        new("Vote.InvalidQuestions", "The provided questions are invalid.", StatusCodes.Status400BadRequest);
}
