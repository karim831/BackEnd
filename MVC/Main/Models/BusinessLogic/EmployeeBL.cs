using Main.Models.Entity;

namespace Main.Models.BusinessLogic;

public class EmployeeBL{
    public static Employee? GetEmployeeById(MVCDbContext context,int id) =>
        context.Employees.FirstOrDefault(e => e.Id == id);
}