namespace SurveyManagement.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        var authResult = await _authService.GetTokenAsync(request.Email, request.Password);
        return authResult is null ? BadRequest("Invalid Email/Password") : Ok(authResult);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenRequest request)
    {
        var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken);
        return authResult is null ? BadRequest("Invalid Token") : Ok(authResult);
    }

    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RefreshTokenRequest request)
    {
        var isRevoked = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken);
        return isRevoked ? Ok() : BadRequest("Operation failed");
    }
}
