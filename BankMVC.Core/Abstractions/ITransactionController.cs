using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ITransactionController
    {
        // get -- requires pin
        IActionResult DisplayTransactions();
        
        // post -- user enters pin and clicks submit
        IActionResult DisplayTransactions(DisplayTransactionsViewModel model);
        
        // get -- displays list of user transactions
        IActionResult UserTransactions();
    }
}