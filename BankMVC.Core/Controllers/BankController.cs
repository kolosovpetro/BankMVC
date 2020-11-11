using BankMVC.Abstractions;
using BankMVC.Services.Interfaces;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class BankController : Controller, IBankController
    {
        private readonly ILoginService _loginService;

        public BankController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

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

            var validateModel = _loginService.ValidateUserNameAndPin(model);

            if (validateModel != true)
                return RedirectToAction("Login", "Bank");

            HttpContext.Session.SetString("CurrentUserName", model.UserName);
            return RedirectToAction("SuccessLoginScreen", "Bank");
        }
        
        [HttpGet]
        public IActionResult SuccessLoginScreen()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CheckBalance()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CheckBalance(IFormCollection collection)
        {
            throw new System.NotImplementedException();
        }
    }
}