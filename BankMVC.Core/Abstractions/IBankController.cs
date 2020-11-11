using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface IBankController
    {
        // login get
        IActionResult Login();
        // login post
        IActionResult Login(IFormCollection collection);

        IActionResult SuccessLoginScreen();

        IActionResult CheckBalance();

        IActionResult CheckBalance(IFormCollection collection);

        IActionResult BalanceDashboard(UserBalanceViewModel model);
        // // balance get
        // IActionResult Balance();
        // // balance post
        // IActionResult Balance(IFormCollection collection);
    }
}