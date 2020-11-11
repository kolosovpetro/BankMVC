using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface IBalanceController
    {
        // get -- user clicks Balance
        IActionResult CheckBalance();
        
        // post -- user enters Pin
        IActionResult CheckBalance(IFormCollection collection);
        
        // get -- user in dashboard if Pin is correct
        IActionResult BalanceDashboard(UserBalanceViewModel model);
    }
}