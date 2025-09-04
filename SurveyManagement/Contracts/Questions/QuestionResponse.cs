using SurveyManagement.Contracts.Answers;

namespace SurveyManagement.Contracts.Questions;

public record QuestionResponse(
    int Id,
    string Content,
    IEnumerable<AnswerResponse> Answers
);
