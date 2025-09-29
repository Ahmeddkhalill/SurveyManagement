namespace SurveyManagement.Errors;

public static class RoleErrors
{
    public static Error NotFound => new(
        "Role.NotFound",
        "The specified role was not found.",
        StatusCodes.Status404NotFound
    );

    public static Error DuplicatedRole => new(
        "Role.DuplicatedRole",
        "A role with the specified name already exists.",
        StatusCodes.Status409Conflict
    );

    public static readonly Error InvalidPermissions =
       new("Role.InvalidPermissions", "Invalid permissions", StatusCodes.Status400BadRequest);
}
