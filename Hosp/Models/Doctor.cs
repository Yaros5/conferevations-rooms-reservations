namespace Hosp.Models;

public class Doctor
{ 
    public int ID { get; set;}
    public string Name { get; set;}
    public string LastName { get; set;}
    public string Profesion { get; set;}
    public string PhoneNumber { get; set; }
    public TimeOnly StartHour {get; set; }
    public TimeOnly FinishHour {get; set; }

    public string Image { get; set; }

}