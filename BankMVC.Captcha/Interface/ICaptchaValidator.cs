using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BankMVC.Captcha.Interface
{
    public interface ICaptchaValidator
    {
        Task<bool> IsCaptchaPassedAsync(string token);
        Task<JObject> GetCaptchaResultDataAsync(string token);
        void UpdateSecretKey(string key);
    }
}
