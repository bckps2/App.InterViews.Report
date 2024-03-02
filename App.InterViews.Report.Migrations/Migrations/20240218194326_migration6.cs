using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Interviewers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surnames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPosition = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviewers_InterViews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "InterViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviewers_InterviewId",
                table: "Interviewers",
                column: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Interviewers");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
