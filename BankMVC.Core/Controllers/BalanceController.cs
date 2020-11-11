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
    }
}