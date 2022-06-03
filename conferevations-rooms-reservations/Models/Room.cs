namespace conferevations_rooms_reservations.Models;

public class Room
{
    public  int Id { get; set; }
    public  string Name { get; set; }
    //some information about room
    public int? CurrentPeople { get; set; }
    
}