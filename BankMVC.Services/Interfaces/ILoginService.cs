using BankMVC.ViewModel.ViewModels;

namespace BankMVC.Services.Interfaces
{
    public interface ILoginService
    {
        bool ValidateUserNameAndPin(LoginViewModel model);
    }
}