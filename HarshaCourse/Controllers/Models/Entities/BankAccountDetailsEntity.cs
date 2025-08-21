namespace Controllers.Models.Entities;

public class BankAccountDetailsEntity{
    public int AccountNumber {get; set;}
    public string AccountHolderName {get; set;} = null!;
    public int CurrentBalance {get; set;}
}