using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Process",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Process_UserId",
                table: "Process",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Users_UserId",
                table: "Process",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Users_UserId",
                table: "Process");

            migrationBuilder.DropIndex(
                name: "IX_Process_UserId",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Process");
        }
    }
}
