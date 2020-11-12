using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Abstractions
{
    public interface ICashController
    {
        /// <summary>
        /// View, shown when user clicks Cash on the first screen. Asks a pin.
        /// </summary>
        IActionResult CashRequest();
        
        /// <summary>
        /// Post request for pin validation form above. If user enters valida data, redirects user to
        /// cash withdraw menu, else redirects to login form.
        /// </summary>
        IActionResult CashRequest(IFormCollection collection);
        
        /// <summary>
        /// Cash withdraw menu. Contains buttons: 50, 100, 200, Other sum.
        /// </summary>
        IActionResult CashRequestMenu();
        
        /// <summary>
        /// Post request from cash withdraw menu. Deducts particular amount from user account
        /// and creates new transaction, saves it all to database. In case of amount is lesser
        /// than zero or grater than user's balance -- redirects back to cash withdraw menu.
        /// </summary>
        IActionResult DeductCashAmount(double amount);
        
        /// <summary>
        /// Notifies user that transaction is proceeded. Redirects to login form after 10 seconds.
        /// </summary>
        IActionResult DeductSuccess();
        
        /// <summary>
        /// View, shown when user clicks Other amount in cash withdraw menu. Contains field "Amount"
        /// and button "Cash.
        /// </summary>
        IActionResult OtherAmount();
        
        /// <summary>
        /// Post request from Other amount view. Verifies that balance and amount is ok,
        /// then deducts amount from user account and creates new transaction. Finally,
        /// saves all to database.
        /// </summary>
        IActionResult OtherAmount(IFormCollection collection);
    }
}