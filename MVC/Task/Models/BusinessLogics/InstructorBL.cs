using Task.Models.Views;

namespace Task.Models.BusinessLogic;

public class InstructorBL{
    public static ShowInstructorByIdViewModel? GetInstructorById(TaskDbContext context,int id){
        return context.Instructors
        .Where(i => i.Id == id)
        .Select(i => new ShowInstructorByIdViewModel(){
            Name = i.Name,
            Image = i.Image,
            Address = i.Address,
            Salary = i.Salary,
            DeptName = i.Department.Name,
            CRSName = i.Course != null ? i.Course.Name : null
        }).FirstOrDefault();
    }

    public static IList<ShowAllInstructorsViewModel> GetAllInstructors(TaskDbContext context) => 
        context.Instructors
        .Select(i => new ShowAllInstructorsViewModel(){
            Id = i.Id,
            Name = i.Name,
            Image = i.Image
        }).ToList();
}