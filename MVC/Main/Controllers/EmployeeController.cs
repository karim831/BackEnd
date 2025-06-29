using Main.Models;
using Main.Models.BusinessLogic;
using Main.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Main.Controllers;

public class EmployeeController: Controller{
    readonly MVCDbContext _context;
    public EmployeeController(MVCDbContext context){
        _context = context;
    }

    public IActionResult GetEmployeeById(int id){
        ViewData["Msg"] = $"Employee With User Id = {id}";
        // ViewData["Date"] = DateTime.UtcNow;
        ViewBag.Date = DateTime.UtcNow;
        return View("ShowEmployeeById",EmployeeBL.GetEmployeeById(_context, id));
    }

    public IActionResult GetEmployeeByIdVM(int id){
        var employee = EmployeeBL.GetEmployeeById(_context, id);
        if(employee is null)
            throw new NullReferenceException($"There's No Employee With This Id = {id}");
        return View(
            "ShowEmployeeByIdVM",
            new EmployeeMsgDateViewModel(){
                Name = employee.Name,
                JobTitle = employee.JobTitle,
                Salary = employee.Salary,
                Msg = $"Employee Of Id = {id}",
                DateNow = DateTime.UtcNow
            }
        );
    }
}