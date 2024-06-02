using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPolicyNumToCustomerPolicyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyNumber",
                table: "CustomerPolicies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolicyNumber",
                table: "CustomerPolicies");
        }
    }
}
