namespace SurveyManagement.Services;

public interface IAuthService
{
    Task<AuthResponse?> GetTokenAsync(string email, string password);
    Task<AuthResponse?> GetRefreshTokenAsync(string token, string refreshToken);
    Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken);
}
