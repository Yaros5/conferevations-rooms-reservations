using Hosp.Data;
using Hosp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data;
using System.ComponentModel.DataAnnotations;


namespace Hosp.Controllers;

public class RegisterController: Controller
{
     private readonly ApplicationDbContext _dbContext;
public RegisterController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

        public async Task<IActionResult> SignIn(Patient body)
        {




            return View(body);
    }
   
    

        public async Task<IActionResult> Registred(Patient body)
    {
        if (ModelState.IsValid)
        {
            // todo: rest of fields
            _dbContext.Patient.Add(body);
            await _dbContext.SaveChangesAsync();
            
            return RedirectToAction("Patient", new{id=body.Id});
        }



        return View(body);
    }

        public async Task<IActionResult> Patient(int id)
        {
            var patient = await _dbContext.Patient.SingleOrDefaultAsync(x => x.Id == id);

        return View(patient);
        }
       


}