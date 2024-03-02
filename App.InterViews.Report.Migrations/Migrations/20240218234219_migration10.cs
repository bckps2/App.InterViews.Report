using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviewers_InterViews_InterviewId",
                table: "Interviewers");

            migrationBuilder.DropIndex(
                name: "IX_Interviewers_InterviewId",
                table: "Interviewers");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Interviewers");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Interviewers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InterviewInterviewers",
                columns: table => new
                {
                    InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewInterviewers", x => new { x.InterviewId, x.InterviewerId });
                    table.ForeignKey(
                        name: "FK_InterviewInterviewers_Interviewers_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Interviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewInterviewers_InterViews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "InterViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviewers_CompanyId",
                table: "Interviewers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewInterviewers_InterviewerId",
                table: "InterviewInterviewers",
                column: "InterviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewers_Companies_CompanyId",
                table: "Interviewers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviewers_Companies_CompanyId",
                table: "Interviewers");

            migrationBuilder.DropTable(
                name: "InterviewInterviewers");

            migrationBuilder.DropIndex(
                name: "IX_Interviewers_CompanyId",
                table: "Interviewers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Interviewers");

            migrationBuilder.AddColumn<Guid>(
                name: "InterviewId",
                table: "Interviewers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Interviewers_InterviewId",
                table: "Interviewers",
                column: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewers_InterViews_InterviewId",
                table: "Interviewers",
                column: "InterviewId",
                principalTable: "InterViews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
