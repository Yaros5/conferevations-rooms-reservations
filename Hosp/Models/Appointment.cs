namespace Hosp.Models;

public class Appointment
{
    public int Id { get; set;}

    public DateTime? Appoint { get; set; }
    
    public Doctor? Doctor {get; set; }
    public int DoctorId { get;set;}
    
    public string? Info { get; set; }
    
    public DateTime? End {get; set;}
    
    public string NamePatient {get; set; }
    
    public string ContactPatient {get; set; }
}
