using SurveyManagement.Contracts.Results;

namespace SurveyManagement.Services;

public interface IResultService
{
    Task<Result<PollVotesResponse>> GetPollVotesAsync(int pollId, CancellationToken cancellationToken = default);
}
