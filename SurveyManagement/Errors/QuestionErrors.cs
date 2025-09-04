namespace SurveyManagement.Errors;

public static class QuestionErrors
{
    public static Error DuplicatedQuestionContent => new(
        "Question.DuplicatedContent",
        "A question with the same content already exists in this poll.",
        StatusCodes.Status409Conflict

    );
    public static Error QuestionNotFound => new(
        "Question.NotFound",
        "The specified question was not found.",
        StatusCodes.Status404NotFound
    );
}
