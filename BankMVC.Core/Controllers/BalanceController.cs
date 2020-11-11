using System;
using BankMVC.Abstractions;
using BankMVC.Services.Implementations;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class BalanceController : Controller, IBalanceController
    {
        private readonly BankService _bankService;

        public BalanceController(BankService bankService)
        {
            _bankService = bankService;
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
            var formPin = collection["Pin"].ToString();
            
            if (!int.TryParse(formPin, out _))
                return RedirectToAction("CheckBalance", "Balance");


            var userName = HttpContext.Session.GetString("CurrentUserName");
            var parsedPin = int.Parse(formPin);
            
            try
            {
                var balance = _bankService.GetBalance(userName, parsedPin);
                return RedirectToAction("BalanceDashboard", balance);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Login", "Login");
            }
        }

        /// <summary>
        /// View of user balance dash board, GET request.
        /// </summary>
        [HttpGet]
        public IActionResult BalanceDashboard(UserBalanceViewModel model)
        {
            return View(model);
        }
    }
}