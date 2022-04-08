namespace Hosp.Models;

public class Appointment
{
    public int Id { get; set;}

    public DateTime? Appoint { get; set; }
    
    public Doctor? Doctor {get; set; }
    public int DoctorId { get;set;}
    
    public DateTime? Begin { get; set; }
    
    public DateTime? End {get; set;}
    
    
}
