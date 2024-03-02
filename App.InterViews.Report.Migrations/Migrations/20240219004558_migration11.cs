using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Interviewers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewers_Email",
                table: "Interviewers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interviewers_Email",
                table: "Interviewers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Interviewers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
