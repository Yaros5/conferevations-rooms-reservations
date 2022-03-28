using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Hosp.Models;

public class Hospital 
{
    public int Id {get; set; }
    [Required] public string NameHospital { get; set; } 

    [Required] 
    public string image { get; set; } = "https://";

    public List<Doctor> Doctors { get; set; } = new();
    [Required]
    public TimeOnly StartWork {get; set; }
    [Required]
    public TimeOnly FinishWork { get; set; }
    [Required]
    [Phone]
    public string ContactNumber {get; set; }


}