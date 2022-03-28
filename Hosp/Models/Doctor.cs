using Hosp.Controllers;

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
    public DateOnly Date {get; set; }
    public string Info { get; set; }
    public string Image { get; set; }
    public Hospital Hospital { get; set; }
    

}