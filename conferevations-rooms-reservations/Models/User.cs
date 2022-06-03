namespace conferevations_rooms_reservations.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public List<Reservation> Reservations { get; set; } = null!;
}