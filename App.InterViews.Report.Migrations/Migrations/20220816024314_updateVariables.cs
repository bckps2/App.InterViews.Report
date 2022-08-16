using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class updateVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    IdProcess = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeSalarial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    ExternalCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyIdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.IdProcess);
                    table.ForeignKey(
                        name: "FK_Process_Companies_CompanyIdCompany",
                        column: x => x.CompanyIdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany");
                });

            migrationBuilder.CreateTable(
                name: "InterViews",
                columns: table => new
                {
                    IdInterview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProcess = table.Column<int>(type: "int", nullable: false),
                    InterViewersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInterView = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeInterView = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProcessIdProcess = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterViews", x => x.IdInterview);
                    table.ForeignKey(
                        name: "FK_InterViews_Process_ProcessIdProcess",
                        column: x => x.ProcessIdProcess,
                        principalTable: "Process",
                        principalColumn: "IdProcess");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyName",
                table: "Companies",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InterViews_ProcessIdProcess",
                table: "InterViews",
                column: "ProcessIdProcess");

            migrationBuilder.CreateIndex(
                name: "IX_Process_CompanyIdCompany",
                table: "Process",
                column: "CompanyIdCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterViews");

            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
