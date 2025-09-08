namespace SurveyManagement.Controllers;

[Route("api/Polls/{PollId}[controller]")]
[ApiController]
[Authorize]

public class ResultsController(IResultService resultService) : ControllerBase
{
    private readonly IResultService _resultService = resultService;

    [HttpGet("row-data")]
    public async Task<IActionResult> PollVotes([FromRoute] int pollId, CancellationToken cancellationToken = default)
    {
        var result = await _resultService.GetPollVotesAsync(pollId, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}