using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Companies_IdCompany",
                table: "Process");

            migrationBuilder.RenameColumn(
                name: "IdCompany",
                table: "Process",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Process_IdCompany",
                table: "Process",
                newName: "IX_Process_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Companies_CompanyId",
                table: "Process",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Companies_CompanyId",
                table: "Process");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Process",
                newName: "IdCompany");

            migrationBuilder.RenameIndex(
                name: "IX_Process_CompanyId",
                table: "Process",
                newName: "IX_Process_IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Companies_IdCompany",
                table: "Process",
                column: "IdCompany",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
