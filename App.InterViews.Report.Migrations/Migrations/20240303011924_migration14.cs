using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviewers_Companies_CompanyId",
                table: "Interviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewInterviewers_Interviewers_InterviewerId",
                table: "InterviewInterviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewInterviewers_InterViews_InterviewId",
                table: "InterviewInterviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewInterviewers",
                table: "InterviewInterviewers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviewers",
                table: "Interviewers");

            migrationBuilder.RenameTable(
                name: "InterviewInterviewers",
                newName: "InterviewInterviewer");

            migrationBuilder.RenameTable(
                name: "Interviewers",
                newName: "Interviewer");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewInterviewers_InterviewerId",
                table: "InterviewInterviewer",
                newName: "IX_InterviewInterviewer_InterviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviewers_Email",
                table: "Interviewer",
                newName: "IX_Interviewer_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Interviewers_CompanyId",
                table: "Interviewer",
                newName: "IX_Interviewer_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewInterviewer",
                table: "InterviewInterviewer",
                columns: new[] { "InterviewId", "InterviewerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviewer",
                table: "Interviewer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersAccount_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surnames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: true),
                    IdentificationDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInfo_UsersAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UsersAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersAccount_RoleId",
                table: "UsersAccount",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserAccountId",
                table: "UsersInfo",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewer_Companies_CompanyId",
                table: "Interviewer",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewInterviewer_Interviewer_InterviewerId",
                table: "InterviewInterviewer",
                column: "InterviewerId",
                principalTable: "Interviewer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewInterviewer_InterViews_InterviewId",
                table: "InterviewInterviewer",
                column: "InterviewId",
                principalTable: "InterViews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_UsersInfo_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviewer_Companies_CompanyId",
                table: "Interviewer");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewInterviewer_Interviewer_InterviewerId",
                table: "InterviewInterviewer");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewInterviewer_InterViews_InterviewId",
                table: "InterviewInterviewer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_UsersInfo_UserId",
                table: "UserCompanies");

            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropTable(
                name: "UsersAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewInterviewer",
                table: "InterviewInterviewer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviewer",
                table: "Interviewer");

            migrationBuilder.RenameTable(
                name: "InterviewInterviewer",
                newName: "InterviewInterviewers");

            migrationBuilder.RenameTable(
                name: "Interviewer",
                newName: "Interviewers");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewInterviewer_InterviewerId",
                table: "InterviewInterviewers",
                newName: "IX_InterviewInterviewers_InterviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviewer_Email",
                table: "Interviewers",
                newName: "IX_Interviewers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Interviewer_CompanyId",
                table: "Interviewers",
                newName: "IX_Interviewers_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewInterviewers",
                table: "InterviewInterviewers",
                columns: new[] { "InterviewId", "InterviewerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviewers",
                table: "Interviewers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdentificationDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surnames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewers_Companies_CompanyId",
                table: "Interviewers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewInterviewers_Interviewers_InterviewerId",
                table: "InterviewInterviewers",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewInterviewers_InterViews_InterviewId",
                table: "InterviewInterviewers",
                column: "InterviewId",
                principalTable: "InterViews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
