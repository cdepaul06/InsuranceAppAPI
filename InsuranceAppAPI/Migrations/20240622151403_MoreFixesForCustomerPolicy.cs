using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class MoreFixesForCustomerPolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicyLines_CustomerPolicyId",
                table: "CustomerPolicyLines");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicyLines_CustomerPolicyId",
                table: "CustomerPolicyLines",
                column: "CustomerPolicyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicyLines_CustomerPolicyId",
                table: "CustomerPolicyLines");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicyLines_CustomerPolicyId",
                table: "CustomerPolicyLines",
                column: "CustomerPolicyId");
        }
    }
}
