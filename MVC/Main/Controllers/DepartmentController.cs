using Main.Models;
using Main.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

public class DepartmentController: Controller{
    readonly MVCDbContext _context;
    public DepartmentController(MVCDbContext context){
        _context = context;
    }
    public IActionResult GetAllDepartments() => 
        View("ShowAllDepartments",DepartmentBL.GetAllDepartments(_context)); 
}