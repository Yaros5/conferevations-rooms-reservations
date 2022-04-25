using Hosp.Data;
using Hosp.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            body.ID = 0;
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

    
    
    [HttpGet]
    public async Task<IActionResult> Delete()
    {
        var doctor = await _dbContext.Doctors.ToListAsync();     
        return View(doctor);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(Doctor body)
    {
        var del = await _dbContext.Doctors.SingleOrDefaultAsync(x => x.NickName == body.NickName);
        _dbContext.Doctors.Remove(del);
        await _dbContext.SaveChangesAsync();


        return RedirectToAction(nameof(List));
    }
    

    
    
    
    
    
    
    
    
    
    
    
    
    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        var doctor = await _dbContext.Doctors.ToListAsync();     
        return View(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Doctor body)
    {
        var search = await _dbContext.Doctors.SingleOrDefaultAsync(x => x.NickName == body.NickName);
    
        return RedirectToAction("EditLogic", new {id = search.ID});
    }
    
    
    [HttpGet]
    public async Task<IActionResult> EditLogic(int id)
    {
            var edit = await _dbContext.Doctors.SingleOrDefaultAsync(x => x.ID == id);
        
            var viewModel = new AddDoctorViewModel();
            viewModel.Doctor = edit;
            viewModel.Hospitals = await _dbContext.Hospitals.ToListAsync();
            return View(viewModel);
        }

    [HttpPost]
    public async Task<IActionResult> EditLogic(Doctor search)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Entry(search).State = EntityState.Modified;
            _dbContext.Doctors.Update(search);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("NewDoctor", new {id = search.ID});
        }


        return RedirectToAction("Edit", new {id = search.ID});
    }

  
    [HttpGet]
    public async Task<IActionResult> Appoitment(int id)
    {
        var appoint = await _dbContext.Doctors.SingleOrDefaultAsync(x => x.ID == id);
        if (appoint == null)
        {
            return RedirectToAction("List");
        }
        return View(appoint);
    }
    [HttpPost]
    public async Task<IActionResult> Appoitment(Appointment appointment)
    {
        var doc =   _dbContext.Doctors.Find(appointment.DoctorId);
        appointment.Id = 0;
        appointment.End = appointment.Appoint + new TimeSpan(0, 0, 30, 0);
        var start = DateTime.Parse(doc.StartHour);
        var finish = DateTime.Parse(doc.FinishHour);
        if (finish.Hour > appointment.Appoint.Value.Hour && start.Hour <= appointment.Appoint.Value.Hour)
        {
            appointment.DoctorId = doc.ID;
            if (_dbContext.Appointment.Where(x => x.DoctorId == appointment.DoctorId).Any(x => x.Appoint == appointment.Appoint))
                    
            {
                return View();
            }

            _dbContext.Appointment.Add(appointment);
            // _dbContext.Appointment.Update(more);
            
            await _dbContext.SaveChangesAsync();


            return RedirectToAction("Done");
        }

        return RedirectToAction("Appoitment", new {id = doc.ID});
    }

    public IActionResult Done()
    {
        return View();
    }


}
