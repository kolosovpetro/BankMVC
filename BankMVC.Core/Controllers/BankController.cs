using BankMVC.Abstractions;
using BankMVC.Services.Interfaces;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class BankController : Controller, IBankController
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
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
                return RedirectToAction("Login", "Bank");

            HttpContext.Session.SetString("CurrentUserName", model.UserName);
            HttpContext.Session.SetInt32("CurrentUserPin", model.Pin);
            return RedirectToAction("SuccessLoginScreen", "Bank");
        }

        /// <summary>
        /// View of user dashboard, GET request.
        /// </summary>
        [HttpGet]
        public IActionResult SuccessLoginScreen()
        {
            return View();
        }

        /// <summary>
        /// View returned if user chooses to check balance
        /// </summary>
        [HttpGet]
        public IActionResult CheckBalance()
        {
            return View();
        }

        /// <summary>
        /// Post request when user enters pin in order to check balance.
        /// </summary>
        [HttpPost]
        public IActionResult CheckBalance(IFormCollection collection)
        {
            var pin = int.Parse(collection["Pin"].ToString());
            var userName = HttpContext.Session.GetString("CurrentUserName");
            var balance = _bankService.GetBalance(userName, pin);
            return RedirectToAction("BalanceDashboard", balance);
        }

        /// <summary>
        /// View of user balance dash board, GET request.
        /// </summary>
        [HttpGet]
        public IActionResult BalanceDashboard(UserBalanceViewModel model)
        {
            return View(model);
        }

        /// <summary>
        /// Asks pin when user goes to cash withdraw
        /// </summary>
        [HttpGet]
        public IActionResult MoneyWithdrawRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MoneyWithdrawRequest(IFormCollection collection)
        {
            var formUserName = HttpContext.Session.GetString("CurrentUserName");
            var formPin = collection["Pin"].ToString();
            var model = new LoginViewModel
            {
                UserName = formUserName,
                Pin = int.Parse(formPin)
            };

            var validateModel = _bankService.ValidateUserNameAndPin(model);

            if (validateModel != true)
                return RedirectToAction("Login", "Bank");
            
            return RedirectToAction("CashWithdrawMenu", "Bank");
        }

        /// <summary>
        /// View of cash withdraw. Shows 50, 100, 200, Other Sum.
        /// </summary>
        [HttpGet]
        public IActionResult CashWithdrawMenu()
        {
            return View();
        }

        // /// <summary>
        // /// Withdraws from user account concrete value
        // /// </summary>
        // [HttpGet]
        // public IActionResult WithdrawMoney(double amount)
        // {
        //     var userName = HttpContext.Session.GetString("CurrentUserName");
        //     var userPin = HttpContext.Session.GetInt32("CurrentUserPin");
        //     
        //     if (userPin == null)
        //         throw new InvalidOperationException("Invalid Pin.");
        //
        //     var encodedPin = _bankService.Encode((int) userPin);
        //     var user = _bankService.GetUserByNameAndPin(userName, encodedPin);
        //
        //     if (user == null)
        //         throw new InvalidOperationException("User not found.");
        //
        //     if (user.Balance >= amount)
        //     {
        //         var balance = user.Balance - amount;
        //         user.Balance = balance;
        //         _bankService.UpdateUser(user);
        //         _bankService.DatabaseSaveChanges();
        //     }
        //     else
        //         throw new InvalidOperationException("Not enough money");
        //
        //     return View();
        // }
    }
}