using System;
using System.Collections.Generic;
using System.Net.Http;
using BankMVC.Models;
using Newtonsoft.Json;

namespace BankMVC.ReCaptchaV2
{
    public static class ReCaptchaValidator
    {
        public static ReCaptchaValidationResult IsValid(string captchaResponse)
        {
            if (string.IsNullOrWhiteSpace(captchaResponse))
            {
                return new ReCaptchaValidationResult
                {
                    Success = false
                };
            }

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://www.google.com")
            };

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("secret", "6Lc_0OsZAAAAADEHrn-xsDZd_ENwWbFIk_VjYzLr"),
                new KeyValuePair<string, string>("response", captchaResponse)
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync("/recaptcha/api/siteverify", content).Result;

            var verificationResponse = response.Content.ReadAsStringAsync().Result;

            var verificationResult = JsonConvert.DeserializeObject
                <ReCaptchaValidationResult>(verificationResponse);

            return verificationResult;
        }
    }
}