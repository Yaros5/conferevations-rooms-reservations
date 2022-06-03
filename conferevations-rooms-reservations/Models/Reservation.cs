namespace conferevations_rooms_reservations.Models;

public class Reservation
{
    public int Id { get; set; }
    public Room Room { get; set; } = null!;
    public User User { get; set; } = null!;
    public int RoomId { get; set; }
    public string? RoomName { get; set; }
    public int UserId { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public DateOnly Date { get; set; }
}
   