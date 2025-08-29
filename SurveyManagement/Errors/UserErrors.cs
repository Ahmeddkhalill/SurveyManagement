namespace SurveyManagement.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new Error("User.InvalidCredentials", "Invalid email/password", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidJwtToken =
        new Error("User.InvalidJwtToken", "Invalid JWT token", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
        new Error("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized);
}
