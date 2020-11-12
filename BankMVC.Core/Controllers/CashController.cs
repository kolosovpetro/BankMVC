using System;
using BankMVC.Abstractions;
using BankMVC.Auxiliary.Encode;
using BankMVC.Model.Models;
using BankMVC.Services.Implementations;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class CashController : Controller, ICashController
    {
        private readonly BankService _bankService;

        public CashController(BankService bankService)
        {
            _bankService = bankService;
        }

        /// <summary>
        /// View, shown when user clicks Cash on the first screen. Asks a pin.
        /// </summary>
        [HttpGet]
        public IActionResult CashRequest()
        {
            return View();
        }

        /// <summary>
        /// Post request for pin validation form above. If user enters valida data, redirects user to
        /// cash withdraw menu, else redirects to login form.
        /// </summary>
        [HttpPost]
        public IActionResult CashRequest(IFormCollection collection)
        {
            var formUserName = HttpContext.Session.GetString("CurrentUserName");
            var formPin = collection["Pin"].ToString();

            if (!int.TryParse(formPin, out _))
                return RedirectToAction("CashRequest", "Cash");

            var model = new LoginViewModel
            {
                UserName = formUserName,
                Pin = int.Parse(formPin)
            };

            var validateModel = _bankService.ValidateUserNameAndPin(model);

            if (validateModel != true)
                return RedirectToAction("Login", "Login");

            return RedirectToAction("CashRequestMenu", "Cash");
        }

        /// <summary>
        /// Cash withdraw menu. Contains buttons: 50, 100, 200, Other sum.
        /// </summary>
        [HttpGet]
        public IActionResult CashRequestMenu()
        {
            return View();
        }

        /// <summary>
        /// Post request from cash withdraw menu. Deducts particular amount from user account
        /// and creates new transaction, saves it all to database. In case of amount is lesser
        /// than zero or grater than user's balance -- redirects back to cash withdraw menu.
        /// </summary>
        [HttpGet]
        public IActionResult DeductCashAmount(double amount)
        {
            var userName = HttpContext.Session.GetString("CurrentUserName");
            var pin = HttpContext.Session.GetInt32("CurrentUserPin");
            if (pin == null)
                throw new InvalidOperationException("Wrong user pin.");
            var encodedPin = new Encoder().Encode((int) pin);
            var user = _bankService.GetUserByNameAndPin(userName, encodedPin);

            if (user == null)
                throw new InvalidOperationException("Wrong user credits.");

            if (user.Balance >= amount && amount > 0)
            {
                user.Balance -= amount;
                _bankService.UpdateUser(user);
                var transaction = new Transaction(user.UserName, -amount, DateTime.Now);
                _bankService.AddTransaction(transaction);
                _bankService.DatabaseSaveChanges();
                return RedirectToAction("DeductSuccess", "Cash");
            }

            return RedirectToAction("CashRequestMenu", "Cash");
        }

        /// <summary>
        /// Notifies user that transaction is proceeded. Redirects to login form after 10 seconds.
        /// </summary>
        [HttpGet]
        public IActionResult DeductSuccess()
        {
            return View();
        }

        /// <summary>
        /// View, shown when user clicks Other amount in cash withdraw menu. Contains field "Amount"
        /// and button "Cash.
        /// </summary>
        [HttpGet]
        public IActionResult OtherAmount()
        {
            return View();
        }

        /// <summary>
        /// Post request from Other amount view. Verifies that balance and amount is ok,
        /// then deducts amount from user account and creates new transaction. Finally,
        /// saves all to database.
        /// </summary>
        [HttpPost]
        public IActionResult OtherAmount(IFormCollection collection)
        {
            var amount = double.Parse(collection["Amount"].ToString());
            return RedirectToAction("DeductCashAmount", "Cash", new {amount});
        }
    }
}