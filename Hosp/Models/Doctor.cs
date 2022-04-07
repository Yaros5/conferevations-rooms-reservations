namespace Hosp.Models;

public class Doctor
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Profesion { get; set; }
    public string PhoneNumber { get; set; }
    public string StartHour { get; set; }
    public string FinishHour { get; set; }
    public string? Info { get; set; }
    public string Image { get; set; }
    public int HospitalId { get; set; }
    public Hospital? Hospital { get; set; }

    public string? NickName { get; set; }

    public string? NickNameFlip { get; set; }
}