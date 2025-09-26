using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04", "b752e97b-8502-4a95-abbd-f4f75130ab93", false, false, "Admin", "ADMIN" },
                    { "d06f8f1f-6d93-427f-a606-5f5d75e3caab", "40372546-db0d-4273-a9e5-21ea28321560", false, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "70d63fef-eac1-4555-9cfd-7a6afbac36b7", 0, "b0dbc800-ac83-4a03-9aaf-5f7c793ec35e", "admin@survey-management.com", true, "Survey Management", "Admin", false, null, "ADMIN@SURVEY-MANAGEMENT.COM", "ADMIN@SURVEY-MANAGEMENT.COM", "AQAAAAIAAYagAAAAEBZwyhm/kH9/y41USFlXcpJQjS07Fyck/sFP9xyLK7+GbJqRAth6QwqRs5mPU8YSvg==", null, false, "4D93B6CFDA0B472AA55A6933AB61AE61", false, "admin@survey-management.com" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "polls:read", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 2, "permissions", "polls:add", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 3, "permissions", "polls:update", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 4, "permissions", "polls:delete", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 5, "permissions", "questions:read", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 6, "permissions", "questions:add", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 7, "permissions", "questions:update", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 8, "permissions", "users:read", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 9, "permissions", "users:add", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 10, "permissions", "users:update", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 11, "permissions", "roles:read", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 12, "permissions", "roles:add", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 13, "permissions", "roles:update", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" },
                    { 14, "permissions", "results:read", "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04", "70d63fef-eac1-4555-9cfd-7a6afbac36b7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d06f8f1f-6d93-427f-a606-5f5d75e3caab");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04", "70d63fef-eac1-4555-9cfd-7a6afbac36b7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb8aef3-0ac2-41a2-be68-52f8b0d2bf04");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70d63fef-eac1-4555-9cfd-7a6afbac36b7");
        }
    }
}
