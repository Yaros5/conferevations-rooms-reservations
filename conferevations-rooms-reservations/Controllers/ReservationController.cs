using conferevations_rooms_reservations.Models;
using conferevations_rooms_reservations.Data;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace conferevations_rooms_reservations.Controllers;
[ApiController]    
[Route("/api/[controller]")]
public class ReservationController:ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ReservationController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{name}")]
    public async Task<Task<Reservation?>> ChooseReservation([FromRoute] string name)
    {
        var search = _dbContext.Reservation.FirstOrDefaultAsync(x => x.RoomName == name);
        var searchreservations = _dbContext.Reservation.SingleOrDefaultAsync(x => x.Id == search.Id);
        return searchreservations;
    }
}