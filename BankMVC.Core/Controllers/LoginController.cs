﻿using BankMVC.Abstractions;
using BankMVC.Services.Implementations;
using BankMVC.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMVC.Controllers
{
    public class LoginController : Controller, ILoginController
    {
        private readonly BankService _bankService;

        public LoginController(BankService bankService)
        {
            _bankService = bankService;
        }

        /// <summary>
        /// First screen. User enters username and pin. Get request.
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post request from first screen. In case user entered valid data, redirects to dashboard,
        /// else shows first screen again.
        /// </summary>
        [HttpPost]
        public IActionResult Login(IFormCollection collection)
        {
            var formUserName = collection["UserName"].ToString();
            var formPin = collection["Pin"].ToString();

            if (!int.TryParse(formPin, out _))
                return RedirectToAction("Login", "Login");

            var model = new LoginViewModel
            {
                UserName = formUserName,
                Pin = int.Parse(formPin)
            };

            var validateModel = _bankService.ValidateUserNameAndPin(model);

            if (validateModel != true)
                return RedirectToAction("Login", "Login");

            HttpContext.Session.SetString("CurrentUserName", model.UserName);
            HttpContext.Session.SetInt32("CurrentUserPin", model.Pin);
            return RedirectToAction("SuccessLoginScreen", "Login");
        }

        /// <summary>
        /// Second screen. User dashboard. Contains buttons: Balance, Cash, Transactions. Get Request.
        /// </summary>
        [HttpGet]
        public IActionResult SuccessLoginScreen()
        {
            return View();
        }
    }
}