using Main.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Models.BusinessLogic;

public class DepartmentBL{
    public static IList<Department> GetAllDepartments(MVCDbContext context) =>
        context.Departments.ToList();
}