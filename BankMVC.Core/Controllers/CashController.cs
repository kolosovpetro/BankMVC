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
        /// Asks pin when user goes to cash withdraw
        /// </summary>
        [HttpGet]
        public IActionResult CashRequest()
        {
            return View();
        }
        
        /// <summary>
        /// Deducts amount of money from user account and redirects to Success view.
        /// </summary>
        [HttpPost]
        public IActionResult CashRequest(IFormCollection collection)
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
                return RedirectToAction("Login", "Login");

            return RedirectToAction("CashRequestMenu", "Cash");
        }

        /// <summary>
        /// View of cash withdraw. Shows 50, 100, 200, Other Sum.
        /// </summary>
        [HttpGet]
        public IActionResult CashRequestMenu()
        {
            return View();
        }
        
        /// <summary>
        /// Deducts amount from user. Creates transaction and saves changes to database.
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

            user.Balance -= amount;
            _bankService.UpdateUser(user);
            var transaction = new Transaction(user.UserName, -amount, DateTime.Now);
            _bankService.AddTransaction(transaction);
            _bankService.DatabaseSaveChanges();
            return RedirectToAction("DeductSuccess", "Cash");
        }
        
        /// <summary>
        /// get -- success message, redirect after 10 seconds
        /// </summary>
        [HttpGet]
        public IActionResult DeductSuccess()
        {
            return View();
        }
        
        /// <summary>
        /// get -- here user enters a value
        /// </summary>
        [HttpGet]
        public IActionResult OtherAmount()
        {
            return View();
        }
        
        /// <summary>
        /// post -- deducts amount from user and redirect to success
        /// </summary>
        [HttpPost]
        public IActionResult OtherAmount(IFormCollection collection)
        {
            var amount = double.Parse(collection["Amount"].ToString());
            return RedirectToAction("DeductCashAmount", "Cash", new {amount});
        }
    }
}