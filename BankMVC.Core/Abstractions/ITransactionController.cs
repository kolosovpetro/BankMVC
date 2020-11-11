using System.Collections.Generic;
using BankMVC.Model.Models;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ITransactionController
    {
        // get -- requires pin
        IActionResult DisplayTransactions();

        // post -- user enters pin and clicks submit
        IActionResult DisplayTransactions(IFormCollection collection);

        // get -- displays list of user transactions
        IActionResult UserTransactions();
    }
}