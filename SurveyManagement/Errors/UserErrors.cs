namespace SurveyManagement.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new Error("User.InvalidCredentials", "Invalid email/password", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidJwtToken =
        new Error("User.InvalidJwtToken", "Invalid JWT token", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
        new Error("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicateEmail =
        new Error("User.DuplicateEmail", "Email address is already in use", StatusCodes.Status400BadRequest);

    public static readonly Error EmailNotConfirmed =
        new Error("User.EmailNotConfirmed", "Email address is not confirmed", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidCode = 
        new Error("User.InvalidCode", "Invalid code", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicatedConfirmation = 
        new Error("User.DuplicatedConfirmation", "Email is already confirmed", StatusCodes.Status400BadRequest);
}
