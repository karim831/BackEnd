using System.Net.Mime;
using Controllers.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers;

public class BankController: Controller{
    private readonly BankAccountDetailsEntity _bankAccount = new BankAccountDetailsEntity(){
        AccountNumber = 1001,
        AccountHolderName = "Example Name",
        CurrentBalance = 5000
    };

    [HttpGet("/")]
    public IActionResult Index() => Content("Welcome to the Best Bank");

    [HttpGet("/account-details")]
    public IActionResult AccountDetails() => Json(_bankAccount);

    [HttpGet("/account-Statment")]
    public IActionResult AccountStatment() => File("DummyPdf.pdf",MediaTypeNames.Application.Pdf);

    [HttpGet("get-current-balance/{accountNumber:int?}")]
    public IActionResult GetCurrentBalance(int? accountNumber){
        if(accountNumber == null)
            return NotFound("Account Number should be supplied");
        
        if(_bankAccount.AccountNumber != accountNumber)
            return BadRequest($"Account Number should be {_bankAccount.AccountNumber}");
        
        return Content(_bankAccount.CurrentBalance.ToString());
    }
}