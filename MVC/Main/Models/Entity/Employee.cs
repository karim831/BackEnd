namespace Main.Models.Entity;

public class Employee{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public int Salary {get; set;}
    public string JobTitle {get; set;} = null!;
    public string? ImageUrl {get; set;}
    public string? Address {get; set;}
    public int DepartmentId {get; set;}
    
    public Department Department {get; set;} = null!;
}