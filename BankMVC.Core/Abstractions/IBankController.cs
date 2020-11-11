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

        IActionResult CashWithdrawMenu();

        IActionResult WithdrawMoney(double amount);
        // // balance get
        // IActionResult Balance();
        // // balance post
        // IActionResult Balance(IFormCollection collection);
    }
}