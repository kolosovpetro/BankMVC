using BankMVC.Auxiliary.Decode;
using BankMVC.Auxiliary.Encode;
using BankMVC.Repositories.Repos;
using BankMVC.Services.Interfaces;
using BankMVC.ViewModel.ViewModels;

namespace BankMVC.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly UserRepository _userRepository;

        public LoginService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateUserNameAndPin(LoginViewModel model)
        {
            var pin = new Encoder().Encode(model.Pin);
            var userName = model.UserName;
            var user = _userRepository.Get(x => x.Pin == pin && x.UserName == userName);
            return user != null;
        }
    }
}