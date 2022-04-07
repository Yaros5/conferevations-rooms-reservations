using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosp.Migrations
{
    public partial class PatientPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Patient",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Patient",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Patient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Patient");
        }
    }
}
