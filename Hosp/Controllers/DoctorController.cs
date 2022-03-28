using Hosp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hosp.Controllers;

public class DoctorController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public DoctorController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> List()
    {
        var doctors = await _dbContext.Doctors.ToListAsync();
        return View(doctors);
    }

    public IActionResult SignIn()
    {
        return View();
    }

    public IActionResult Registred()
    {
        return View();
    }
}