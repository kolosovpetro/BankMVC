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

        [HttpGet]
        public IActionResult DisplayTransactions()
        {
            return View();
        }

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