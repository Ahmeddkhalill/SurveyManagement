using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDisabledColumnToUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70d63fef-eac1-4555-9cfd-7a6afbac36b7",
                columns: new[] { "IsDisabled", "PasswordHash" },
                values: new object[] { false, "AQAAAAIAAYagAAAAEEhzk2+CpHE9quLmEN0MF9Pg8DzZuvWEkksXXl8LfSgBqL3G60sJWl4+yP16Pt1urw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70d63fef-eac1-4555-9cfd-7a6afbac36b7",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBZwyhm/kH9/y41USFlXcpJQjS07Fyck/sFP9xyLK7+GbJqRAth6QwqRs5mPU8YSvg==");
        }
    }
}
