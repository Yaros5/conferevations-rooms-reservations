namespace Hosp.Models;

public class Patient
{
    public int Id { get;  set;}
    public string Name { get; set; }
    public string LastName { get; set;}
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    public string Image { get; set; } = "https\\";
    
    public string Sex {get; set; }
    
    public int Year { get; set; }
}