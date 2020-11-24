using System.Collections.Generic;
using Newtonsoft.Json;

namespace BankMVC.Models
{
    public class ReCaptchaValidationResult
    {
        public bool Success { get; set; }
        public string HostName { get; set; }
        [JsonProperty("challenge_ts")] public string TimeStamp { get; set; }
        [JsonProperty("error-codes")] public List<string> ErrorCodes { get; set; }
    }
}