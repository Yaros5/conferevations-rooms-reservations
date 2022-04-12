using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosp.Migrations
{
    public partial class Listed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUse",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "TimeName",
                table: "Doctors",
                newName: "Appointment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Appointment",
                table: "Doctors",
                newName: "TimeName");

            migrationBuilder.AddColumn<bool>(
                name: "IsUse",
                table: "Doctors",
                type: "INTEGER",
                nullable: true);
        }
    }
}
