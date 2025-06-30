namespace Task.Models.Entities;

public class Trainee{
    public int Id {get;set;}
    public string Name {get;set;} = null!;
    public string? Image {get;set;}
    public string? Address {get;set;}
    public int Grade {get;set;}
    public int DeptId {get;set;}

    public IList<CRSResult>? CRSResults {get;set;}
    public Department Department{get;set;} = null!;
}