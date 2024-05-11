using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class Rebase51124b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserType",
                table: "UserType");

            migrationBuilder.RenameTable(
                name: "UserType",
                newName: "UserTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                newName: "UserType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserType",
                table: "UserType",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
