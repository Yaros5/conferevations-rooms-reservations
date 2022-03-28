using Hosp.Data;
using Hosp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data;
using System.ComponentModel.DataAnnotations;



namespace Hosp.Controllers;

public class DoctorController : Controller
{


    private readonly ApplicationDbContext _dbContext;


    public DoctorController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IActionResult Sad()
    {
        return View();
    }

    public async Task<IActionResult> List()
    {
        var doctors = await _dbContext.Doctors
            .Include(x => x.Hospital)
            .ToListAsync();


        return View(doctors);
    }

    public IActionResult Index(string query)
    {

        return View();
    }

    public async Task<IActionResult> Doctor(string query)
    {
        query = query?.ToLower();
        var search = await _dbContext.Doctors
            .Where(x => !string.IsNullOrWhiteSpace(query) && (x.Name.ToLower().Contains(query) ||
                                                              x.LastName.ToLower().Contains(query) ||
                                                              x.Profesion.ToLower().Contains(query)))
            .Include(x => x.Hospital)
            .ToListAsync();

        if (search.Count == 0)
            return RedirectToAction("Sad");

        return View(search);
    }









    



}