using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosp.Migrations
{
    public partial class DocotorDateInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Doctors");
        }
    }
}
