using SurveyManagement.Contracts.Votes;

namespace SurveyManagement.Services;

public interface IVoteService
{
    Task<Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default);
}
