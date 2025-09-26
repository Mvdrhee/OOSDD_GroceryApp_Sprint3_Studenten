
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.App.Views;

namespace Grocery.App.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly GlobalViewModel _global;

        [ObservableProperty]
        private string name = "";

        [ObservableProperty]
        private string email = "";

        [ObservableProperty]
        private string password = "";

        [ObservableProperty]
        private string registerMessage = "";

        public RegisterViewModel(IAuthService authService, GlobalViewModel global)
        { //_authService = App.Services.GetServices<IAuthService>().FirstOrDefault();
            _authService = authService;
            _global = global;
        }

        [RelayCommand]
        private void Register()
        {
            Client? Client = _authService.Register(Name, Email, Password);
            if (Client != null)
            {
                RegisterMessage = $"Welkom {Client.Name}!";
                _global.Client = Client;
                Application.Current.MainPage = new LoginView(new LoginViewModel(_authService, new GlobalViewModel()));
            }
            else
            {
                RegisterMessage = "Het emailadres is ongeldig of al in gebruik";
            }
        }
    }
}
