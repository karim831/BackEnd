namespace Main.Models.Entity;

public class Department{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public string? ManagerName {get; set;}
    public IList<Employee>? Employees {get; set;}
}