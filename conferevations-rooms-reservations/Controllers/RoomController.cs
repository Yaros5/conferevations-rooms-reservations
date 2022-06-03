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
public class RoomController: ControllerBase
{
    private  readonly ApplicationDbContext _dbContext;


    public RoomController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet("")]
    public async Task<List<Room>> ListRoom()
    {
        var data = await _dbContext.Room.ToListAsync();
        return data;
    }
}
