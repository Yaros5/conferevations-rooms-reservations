namespace Hosp.Models;

public class Hospital
{
    public int Id {get; set; }
    public string NameHospital {get; set;}
    public List<Doctor> Doctors {get; set; }
    public TimeOnly StartWork {get; set; }
    public TimeOnly FinishWork { get; set; }
    public string ContactNumber {get; set; }
    
}