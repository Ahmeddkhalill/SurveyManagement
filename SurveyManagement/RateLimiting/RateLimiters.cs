namespace SurveyManagement.RateLimiting;

public static class RateLimiters
{
    public const string IpLimiter = "IpLimiter";
    public const string UserLimiter = "UserLimiter";
    public const string ConcurrencyLimiter = "ConcurrencyLimiter";
}