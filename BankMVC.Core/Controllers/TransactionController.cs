using System;
using BankMVC.Abstractions;
using BankMVC.Auxiliary.Encode;
using BankMVC.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class TransactionController : Controller, ITransactionController
    {
        private readonly BankService _bankService;

        public TransactionController(BankService bankService)
        {
            _bankService = bankService;
        }
        
        /// <summary>
        /// Get request. User enters pin here.
        /// </summary>
        [HttpGet]
        public IActionResult DisplayTransactions()
        {
            return View();
        }
        
        /// <summary>
        /// Post request. User clicks submit here.
        /// </summary>
        [HttpPost]
        public IActionResult DisplayTransactions(IFormCollection collection)
        {
            var userPin = int.Parse(collection["Pin"].ToString());
            var userName = HttpContext.Session.GetString("CurrentUserName");
            var encodedPin = new Encoder().Encode(userPin);
            var user = _bankService.GetUserByNameAndPin(userName, encodedPin);
            if (user == null)
                throw new InvalidOperationException("Wrong user credits.");
            return RedirectToAction("UserTransactions", "Transaction");
        }
        
        /// <summary>
        /// Get request. User is redirected to list of his transactions.
        /// </summary>
        [HttpGet]
        public IActionResult UserTransactions()
        {
            var userName = HttpContext.Session.GetString("CurrentUserName");
            var transactions = _bankService
                .GetUserTransactions(userName);
            return View(transactions);
        }
    }
}