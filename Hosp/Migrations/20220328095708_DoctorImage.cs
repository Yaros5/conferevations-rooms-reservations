using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosp.Migrations
{
    public partial class DoctorImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctors");
        }
    }
}
