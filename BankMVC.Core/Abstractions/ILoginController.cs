using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ILoginController
    {
        /// <summary>
        /// First screen. User enters username and pin. Get request.
        /// </summary>
        IActionResult Login();

        /// <summary>
        /// Post request from first screen. In case user entered valid data, redirects to dashboard,
        /// else shows first screen again.
        /// </summary>
        IActionResult Login(IFormCollection collection);
        
        /// <summary>
        /// Second screen. User dashboard. Contains buttons: Balance, Cash, Transactions. Get Request.
        /// </summary>
        IActionResult SuccessLoginScreen();
    }
}