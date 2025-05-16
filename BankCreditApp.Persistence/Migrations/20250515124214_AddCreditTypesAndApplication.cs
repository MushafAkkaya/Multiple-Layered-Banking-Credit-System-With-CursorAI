using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankCreditApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCreditTypesAndApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinTerm = table.Column<int>(type: "int", nullable: false),
                    MaxTerm = table.Column<int>(type: "int", nullable: false),
                    BaseInterestRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinAnnualTurnover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinCompanyAge = table.Column<int>(type: "int", nullable: false),
                    RequiresCollateral = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCreditTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCreditTypes_CreditTypes_Id",
                        column: x => x.Id,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestedTerm = table.Column<int>(type: "int", nullable: false),
                    ApprovedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovedTerm = table.Column<int>(type: "int", nullable: true),
                    AssignedInterestRate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditApplications_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinCreditScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MinMonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: true),
                    RequiresGuarantor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCreditTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCreditTypes_CreditTypes_Id",
                        column: x => x.Id,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCreditApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentAnnualTurnover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyAgeInMonths = table.Column<int>(type: "int", nullable: false),
                    HasCollateral = table.Column<bool>(type: "bit", nullable: false),
                    CollateralValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCreditApplications_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorporateCreditApplications_CreditApplications_Id",
                        column: x => x.Id,
                        principalTable: "CreditApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCreditApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentCreditScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasGuarantor = table.Column<bool>(type: "bit", nullable: false),
                    GuarantorIdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCreditApplications_CreditApplications_Id",
                        column: x => x.Id,
                        principalTable: "CreditApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualCreditApplications_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCreditApplications_CorporateCustomerId",
                table: "CorporateCreditApplications",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_CreditTypeId",
                table: "CreditApplications",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCreditApplications_IndividualCustomerId",
                table: "IndividualCreditApplications",
                column: "IndividualCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateCreditApplications");

            migrationBuilder.DropTable(
                name: "CorporateCreditTypes");

            migrationBuilder.DropTable(
                name: "IndividualCreditApplications");

            migrationBuilder.DropTable(
                name: "IndividualCreditTypes");

            migrationBuilder.DropTable(
                name: "CreditApplications");

            migrationBuilder.DropTable(
                name: "CreditTypes");
        }
    }
}
