using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerPolicyLines",
                columns: table => new
                {
                    CustomerPolicyLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicyLines", x => x.CustomerPolicyLineId);
                    table.ForeignKey(
                        name: "FK_CustomerPolicyLines_CustomerPolicies_CustomerPolicyId",
                        column: x => x.CustomerPolicyId,
                        principalTable: "CustomerPolicies",
                        principalColumn: "CustomerPolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automobiles",
                columns: table => new
                {
                    AutomobileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPolicyLineId = table.Column<int>(type: "int", nullable: false),
                    MSRP = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiles", x => x.AutomobileId);
                    table.ForeignKey(
                        name: "FK_Automobiles_CustomerPolicyLines_CustomerPolicyLineId",
                        column: x => x.CustomerPolicyLineId,
                        principalTable: "CustomerPolicyLines",
                        principalColumn: "CustomerPolicyLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    HomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPolicyLineId = table.Column<int>(type: "int", nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: false),
                    SquareFootage = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_Homes_CustomerPolicyLines_CustomerPolicyLineId",
                        column: x => x.CustomerPolicyLineId,
                        principalTable: "CustomerPolicyLines",
                        principalColumn: "CustomerPolicyLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPolicyLineId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.MotorcycleId);
                    table.ForeignKey(
                        name: "FK_Motorcycles_CustomerPolicyLines_CustomerPolicyLineId",
                        column: x => x.CustomerPolicyLineId,
                        principalTable: "CustomerPolicyLines",
                        principalColumn: "CustomerPolicyLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_CustomerPolicyLineId",
                table: "Automobiles",
                column: "CustomerPolicyLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicyLines_CustomerPolicyId",
                table: "CustomerPolicyLines",
                column: "CustomerPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_CustomerPolicyLineId",
                table: "Homes",
                column: "CustomerPolicyLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_CustomerPolicyLineId",
                table: "Motorcycles",
                column: "CustomerPolicyLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobiles");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "CustomerPolicyLines");
        }
    }
}
