namespace Task.Models.Views;

public class ShowInstructorByIdViewModel{
    public string Name {get;set;} = null!;
    public string? Image {get;set;}
    public string? Address {get;set;}
    public int Salary {get; set;}
    public string DeptName {get;set;} = null!;
    public string? CRSName {get; set;}
}