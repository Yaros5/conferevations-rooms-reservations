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


        _dbContext.Hospitals.Remove(del);
        await _dbContext.SaveChangesAsync();


        return RedirectToAction(nameof(HospitalList));
    }


    public async Task<IActionResult> Edit(int id)
    {
        var edit = await _dbContext.Hospitals.SingleOrDefaultAsync(x => x.Id == id);
        return View(edit);
    }

    public async Task<IActionResult> EditHospital(Hospital body)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Entry(body).State = EntityState.Modified;
            _dbContext.Hospitals.Update(body);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Hospital", new {id = body.Id});
        }

        return View(body);
    }

    public IActionResult Appoitment()
    {
        throw new NotImplementedException();
    }
}