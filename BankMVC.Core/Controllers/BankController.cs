using BankMVC.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class BankController : Controller, IBankController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(IFormCollection collection)
        {
            throw new System.NotImplementedException();
        }
    }
}