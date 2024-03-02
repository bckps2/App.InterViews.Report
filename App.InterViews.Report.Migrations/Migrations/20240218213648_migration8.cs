using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "UserCompanies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Process",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "InterViews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Interviewers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "UserCompanies");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "InterViews");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Interviewers");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Companies");
        }
    }
}
