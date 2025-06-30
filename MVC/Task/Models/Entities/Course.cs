namespace Task.Models.Entities;

public class Course{
    public int Id {get;set;}
    public string Name {get;set;} = null!;
    public int MaxDegree {get;set;}
    public int MinDegree {get;set;}
    public int Hours {get;set;}
    public int DeptId {get;set;}

    public IList<Instructor>? Instructors {get; set;}
    public IList<CRSResult>? CRSResults {get; set;}
    public Department Department {get; set;} = null!;
    
}