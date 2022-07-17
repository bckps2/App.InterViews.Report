using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class InitialCreate : Migration
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
                name: "InterViews",
                columns: table => new
                {
                    IdInterView = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeSalarial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyIdCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterViews", x => x.IdInterView);
                    table.ForeignKey(
                        name: "FK_InterViews_Companies_CompanyIdCompany",
                        column: x => x.CompanyIdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationInterViews",
                columns: table => new
                {
                    IdInformation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterViewIdInterView = table.Column<int>(type: "int", nullable: false),
                    InterViewersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInterView = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeInterView = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationInterViews", x => x.IdInformation);
                    table.ForeignKey(
                        name: "FK_InformationInterViews_InterViews_InterViewIdInterView",
                        column: x => x.InterViewIdInterView,
                        principalTable: "InterViews",
                        principalColumn: "IdInterView",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyName",
                table: "Companies",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformationInterViews_InterViewIdInterView",
                table: "InformationInterViews",
                column: "InterViewIdInterView");

            migrationBuilder.CreateIndex(
                name: "IX_InterViews_CompanyIdCompany",
                table: "InterViews",
                column: "CompanyIdCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationInterViews");

            migrationBuilder.DropTable(
                name: "InterViews");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
