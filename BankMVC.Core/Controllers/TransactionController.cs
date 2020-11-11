using BankMVC.Abstractions;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class TransactionController : Controller, ITransactionController
    {
        [HttpGet]
        public IActionResult DisplayTransactions()
        {
            throw new System.NotImplementedException();
        }
        
        [HttpPost]
        public IActionResult DisplayTransactions(DisplayTransactionsViewModel model)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public IActionResult UserTransactions()
        {
            throw new System.NotImplementedException();
        }
    }
}