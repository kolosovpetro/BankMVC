using BankMVC.Abstractions;
using BankMVC.Services.Implementations;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class LoginController : Controller, ILoginController
    {
        private readonly BankService _bankService;

        public LoginController(BankService bankService)
        {
            _bankService = bankService;
        }

        /// <summary>
        /// Redirects to the login form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post request from login form. Redirects to user dashboard.
        /// </summary>
        [HttpPost]
        public IActionResult Login(IFormCollection collection)
        {
            var formUserName = collection["UserName"].ToString();
            var formPin = collection["Pin"].ToString();
            var model = new LoginViewModel
            {
                UserName = formUserName,
                Pin = int.Parse(formPin)
            };

            var validateModel = _bankService.ValidateUserNameAndPin(model);

            if (validateModel != true)
                return RedirectToAction("Login", "Login");

            HttpContext.Session.SetString("CurrentUserName", model.UserName);
            HttpContext.Session.SetInt32("CurrentUserPin", model.Pin);
            return RedirectToAction("SuccessLoginScreen", "Login");
        }

        /// <summary>
        /// View of user dashboard, GET request.
        /// </summary>
        [HttpGet]
        public IActionResult SuccessLoginScreen()
        {
            return View();
        }
    }
}