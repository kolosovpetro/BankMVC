using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ILoginController
    {
        // login get
        IActionResult Login();

        // login post
        IActionResult Login(IFormCollection collection);

        IActionResult SuccessLoginScreen();
    }
}