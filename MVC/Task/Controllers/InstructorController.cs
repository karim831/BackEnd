using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Models.BusinessLogic;

namespace Task.Controllers;

public class InstructorController: Controller{
    readonly TaskDbContext _context;
    public InstructorController(TaskDbContext context){
        _context = context;
    }


    public IActionResult GetInstructorById(int id){
        if(id <= 0)
            return BadRequest("Invalid Instructor Id.");
        
        var Instructor = InstructorBL.GetInstructorById(_context,id);

        if(Instructor == null)
            return NotFound($"Instructor With Id = {id} Is Not Found.");
        
        return View("ShowInstructorById",Instructor);
    }

    public IActionResult GetAllInstructors() => 
        View("ShowAllInstructors",InstructorBL.GetAllInstructors(_context));
}