using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface IBalanceController
    {
        /// <summary>
        /// It is pin validation form, after user clicks to Balance on first screen. Get Request.
        /// </summary>
        IActionResult CheckBalance();
        
        /// <summary>
        /// Post request from pin validation form. In case user enters valid data -- shows balance,
        /// else redirects to login form.
        /// </summary>
        IActionResult CheckBalance(IFormCollection collection);
        
        /// <summary>
        /// User balance dashboard. Get request.
        /// </summary>
        IActionResult BalanceDashboard(UserBalanceViewModel model);
    }
}