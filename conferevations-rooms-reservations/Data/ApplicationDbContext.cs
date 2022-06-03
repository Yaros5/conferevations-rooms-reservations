using conferevations_rooms_reservations.Models;

using Microsoft.EntityFrameworkCore;

namespace conferevations_rooms_reservations.Data;

public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }


    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Room> Room { get; set; }
}