using BankMVC.Abstractions;
using BankMVC.Services.Implementations;
using BankMVC.ViewModel.ViewModels;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class LoginController : Controller, ILoginController
    {
        private readonly BankService _bankService;
        private readonly ICaptchaValidator _captchaValidator;

        public LoginController(BankService bankService, ICaptchaValidator captchaValidator)
        {
            _bankService = bankService;
            _captchaValidator = captchaValidator;
        }

        /// <summary>
        /// First screen. User enters username and pin. Get request.
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post request from first screen. In case user entered valid data, redirects to dashboard,
        /// else shows first screen again.
        /// </summary>
        [HttpPost]
        public IActionResult Login(IFormCollection collection, string captcha)
        {
            var formUserName = collection["UserName"].ToString();
            var formPin = collection["Pin"].ToString();

            if (!int.TryParse(formPin, out _))
                return RedirectToAction("Login", "Login");

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
            
            if (_captchaValidator.IsCaptchaPassedAsync(captcha).Result)
                return RedirectToAction("SuccessLoginScreen", "Login");
            
            return RedirectToAction("Login", "Login");
        }

        /// <summary>
        /// Second screen. User dashboard. Contains buttons: Balance, Cash, Transactions. Get Request.
        /// </summary>
        [HttpGet]
        public IActionResult SuccessLoginScreen()
        {
            return View();
        }
    }
}