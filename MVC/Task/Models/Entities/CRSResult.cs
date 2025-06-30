namespace Task.Models.Entities;

public class CRSResult{
    public int Id {get;set;}
    public int Degree {get;set;}
    public int CRSId {get;set;}
    public int TraineeId {get;set;}

    public Trainee Trainee {get;set;} = null!;
    public Course Course {get;set;} = null!;
}