using Hosp.Data;
using Hosp.Models;
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


    public async Task<IActionResult> AddDoctor(Doctor body)
    {
        
        if (ModelState.IsValid)
        {
            body.NickName = $"{body.Name} {body.LastName}";
            body.NickNameFlip = $"{body.LastName} {body.Name}";
            _dbContext.Doctors.Add(body);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("NewDoctor", new {id = body.ID});
        }
        
        var viewModel = new AddDoctorViewModel();
        viewModel.Doctor = body;
        viewModel.Hospitals = await _dbContext.Hospitals.ToListAsync();

        return View(viewModel);
    }

    public async Task<IActionResult> NewDoctor(int id)
    {
        var doctor = await _dbContext.Doctors.SingleOrDefaultAsync(x => x.ID == id);
        return View(doctor);
    }

    public async Task<IActionResult> Delete(int id)
    {
         var del = await _dbContext.Doctors.SingleOrDefaultAsync(x => x.ID == id );


        _dbContext.Doctors.Remove(del);
        await _dbContext.SaveChangesAsync();


        return RedirectToAction(nameof(List));
    }

    public async Task<IActionResult> Edit(int id)
    {        
        var edit = await _dbContext.Doctors.SingleOrDefaultAsync(x => x.ID == id);

        var viewModel = new AddDoctorViewModel();
        viewModel.Doctor = edit;
        viewModel.Hospitals = await _dbContext.Hospitals.ToListAsync();
        return View(viewModel);
    }
    public async Task<IActionResult> EditDoctor(Doctor body)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Entry(body).State = EntityState.Modified;
            _dbContext.Doctors.Update(body);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("NewDoctor", new {id = body.ID});
        }

        return RedirectToAction("Sad");
    }
}
