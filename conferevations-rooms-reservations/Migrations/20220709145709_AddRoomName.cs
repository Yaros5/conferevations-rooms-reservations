using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conferevationsroomsreservations.Migrations
{
    public partial class AddRoomName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Reservation",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Reservation");
        }
    }
}
