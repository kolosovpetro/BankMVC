using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ICashController
    {
        // get -- user clicks Cash
        IActionResult CashRequest();
        
        // post -- user enters Pin 
        IActionResult CashRequest(IFormCollection collection);
        
        // get -- user redirected to menu of 50, 100, 200, Other amount
        IActionResult CashRequestMenu();
        
        // post -- deducts amount of money from user account
        IActionResult DeductCashAmount(double amount);

        IActionResult DeductSuccess();
    }
}