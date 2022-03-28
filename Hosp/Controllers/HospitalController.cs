using Hosp.Data;
using Hosp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Hosp.Controllers;

public class HospitalController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public HospitalController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> HospitalList()
    {
        var hospital = await _dbContext.Hospitals.ToListAsync();

        return View(hospital);
    }

    public async Task<IActionResult> AddHospital(Hospital body)
    {
        if (ModelState.IsValid)
        {
            // todo: rest of fields
            _dbContext.Hospitals.Add(body);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Hospital", new {id = body.Id});
        }


        return View(body);
    }

    public async Task<IActionResult> Hospital(int id)
    {
        var hospital = await _dbContext.Hospitals.SingleOrDefaultAsync(x => x.Id == id);

        return View(hospital);
    }



    public async Task<IActionResult> Delete(int id)
    {
        
        var del = await _dbContext.Hospitals.SingleOrDefaultAsync(x => x.Id == id);
        var dem = _dbContext.Hospitals.Find(id);
        if (del.Id  == dem.Id)
        {
            Console.WriteLine(del);
            _dbContext.Hospitals.Remove(del);
         await _dbContext.SaveChangesAsync();
        }

        return RedirectToAction(nameof(HospitalList));
    } 
    
    
}