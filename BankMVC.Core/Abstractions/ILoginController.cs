using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ILoginController
    {
        // get -- user enters username and pin
        IActionResult Login();

        // post -- user clicks submit
        IActionResult Login(IFormCollection collection);
        
        // get -- redirects to user dashboard
        IActionResult SuccessLoginScreen();
    }
}