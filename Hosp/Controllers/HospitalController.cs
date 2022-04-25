using Hosp.Data;
using Hosp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return View(new Hospital());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Hospital body)
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
        if (hospital == null)
            return RedirectToAction("HospitalList");
        return View(hospital);
    }


    [HttpGet]
    public async Task<IActionResult> Delete()
    {
        var doctor = await _dbContext.Hospitals.ToListAsync();     
        return View(doctor);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(Hospital body)
    {
        var del = await _dbContext.Hospitals.SingleOrDefaultAsync(x => x.NameHospital == body.NameHospital);
        _dbContext.Hospitals.Remove(del);
        await _dbContext.SaveChangesAsync();


        return RedirectToAction(nameof(HospitalList));
    }



    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        var hospitals = await _dbContext.Hospitals.ToListAsync();     
        return View(hospitals);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Hospital body)
    {
        var search = await _dbContext.Hospitals.SingleOrDefaultAsync(x => x.NameHospital == body.NameHospital);
    
        return RedirectToAction("EditLogic", new {id = search.Id});
    }
    [HttpGet]
    public async Task<IActionResult> EditLogic(int id)
    {
        var edit = await _dbContext.Hospitals.SingleOrDefaultAsync(x => x.Id == id);
        
     
        return View(edit);
    }

    [HttpPost]
    public async Task<IActionResult> EditLogic(Hospital search)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Entry(search).State = EntityState.Modified;
            _dbContext.Hospitals.Update(search);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Hospital", new {id = search.Id});
        }


        return RedirectToAction("Edit", new {id = search.Id});
    }

    
    
    
    
    
    
    



}