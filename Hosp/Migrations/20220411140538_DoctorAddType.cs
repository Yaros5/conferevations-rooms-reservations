using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosp.Migrations
{
    public partial class DoctorAddType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentFinish",
                table: "Doctors",
                newName: "TimeName");

            migrationBuilder.RenameColumn(
                name: "Appointment",
                table: "Doctors",
                newName: "End");

            migrationBuilder.AddColumn<DateTime>(
                name: "Begin",
                table: "Doctors",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Begin",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "TimeName",
                table: "Doctors",
                newName: "AppointmentFinish");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Doctors",
                newName: "Appointment");
        }
    }
}
