using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ITransactionController
    {
        /// <summary>
        /// View, shown when user clicks to Transactions on the first screen. Asks user for pin.
        /// </summary>
        IActionResult DisplayTransactions();

        /// <summary>
        /// Post request when user enters pin in order to check transactions. If user enters valid
        /// data, then redirects to User transactions. Else redirects to login form.
        /// </summary>
        IActionResult DisplayTransactions(IFormCollection collection);

        /// <summary>
        /// Returns a list of current user transactions.
        /// </summary>
        IActionResult UserTransactions();
    }
}