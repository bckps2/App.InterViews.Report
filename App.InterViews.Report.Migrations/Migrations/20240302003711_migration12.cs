using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterViews_Process_IdProcess",
                table: "InterViews");

            migrationBuilder.RenameColumn(
                name: "IdProcess",
                table: "InterViews",
                newName: "ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_InterViews_IdProcess",
                table: "InterViews",
                newName: "IX_InterViews_ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterViews_Process_ProcessId",
                table: "InterViews",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterViews_Process_ProcessId",
                table: "InterViews");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "InterViews",
                newName: "IdProcess");

            migrationBuilder.RenameIndex(
                name: "IX_InterViews_ProcessId",
                table: "InterViews",
                newName: "IX_InterViews_IdProcess");

            migrationBuilder.AddForeignKey(
                name: "FK_InterViews_Process_IdProcess",
                table: "InterViews",
                column: "IdProcess",
                principalTable: "Process",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
