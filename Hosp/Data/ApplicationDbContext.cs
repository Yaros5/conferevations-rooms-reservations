using Hosp.Models;
using Microsoft.EntityFrameworkCore;

namespace Hosp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
}