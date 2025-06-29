using Main.Models.Entity;

namespace Main.Models.ViewModels;

public class EmployeeMsgDateViewModel{
    public string Name {get; set;} = null!;
    public string JobTitle{get; set;} = null!;
    public int Salary {get; set;} 
    public string Msg {get; set;} = null!;
    public DateTime DateNow {get; set;}
}