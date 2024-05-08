using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyStatuses",
                columns: table => new
                {
                    PolicyStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyStatuses", x => x.PolicyStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                columns: table => new
                {
                    PolicyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.PolicyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicies",
                columns: table => new
                {
                    CustomerPolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    PolicyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PolicyTypeId = table.Column<int>(type: "int", nullable: false),
                    PolicyStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicies", x => x.CustomerPolicyId);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_PolicyStatuses_PolicyStatusId",
                        column: x => x.PolicyStatusId,
                        principalTable: "PolicyStatuses",
                        principalColumn: "PolicyStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerId",
                table: "CustomerPolicies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_PolicyStatusId",
                table: "CustomerPolicies",
                column: "PolicyStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPolicies");

            migrationBuilder.DropTable(
                name: "PolicyTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PolicyStatuses");
        }
    }
}
