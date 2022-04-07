using System.ComponentModel.DataAnnotations;

namespace Hosp.Models;

public class Hospital
{
    public int Id { get; set; }
    [Required] public string NameHospital { get; set; }

    [Required] public string image { get; set; } = "https://";

    public List<Doctor> Doctors { get; set; } = new();

    [Required] public string StartWork { get; set; }

    [Required] public string FinishWork { get; set; }

    [Required] [Phone] public string ContactNumber { get; set; }
}