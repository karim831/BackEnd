using Main.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
namespace Main.Controllers;

public class StudentController : Controller{
    
    public IActionResult GetAllStudents() => View("ShowAllStudents",new StudentBL().GetAllStudents()); 
        
    

    public IActionResult GetStudentById(int id) => 
        View("ShowStudentById",new StudentBL().GetStudentById(id));
}