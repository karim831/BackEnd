namespace Task.Models.Entities;

public class Department{
    public int Id {get;set;}
    public string Name {get;set;} = null!;
    public string ManagerName {get;set;} = null!;

    public IList<Instructor>? Instructors {get;set;}
    public IList<Trainee>? Trainees {get;set;}
    public IList<Course>? Courses {get;set;}
}