namespace Task.Models.Entities;

public class Instructor{
    public int Id {get;set;}
    public string Name {get;set;} = null!;
    public string? Image {get;set;}
    public string? Address {get;set;}
    public int Salary {get; set;}
    public int DeptId {get;set;}
    public int? CRSId {get; set;}

    public Course? Course {get;set;}
    public Department Department {get;set;} = null!;

}