using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.Infrastrcture;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
using NovaPoshta.Views.Employees;
using NovaPoshta.Views.HomeView;
using NovaPoshta.Views.Login;
using NovaPoshta.Views.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class LoginViewModel:BaseNotifyOfPropertyChanged
    {
        public string Login { get; set; }
        public ICommand LoginCommand { get; set; }
        public LoginViewModel() {
        
            LoginCommand = new RelayCommand(async (obj) =>
            {
                MainViewModel model= (Switcher.ContentArea as MainViewModel);
                IHavePassword pass=(model.CurrentView as IHavePassword);
                string password = pass.GetPassword();
                Switcher.Switch(new AuthorizationProcess());
                Employee employee= await AuthenticationService.LoginAsync(Login, password);
                if(employee != null)
                {
                    Switcher.Switch(new HomeView());
                    HomeSwitcher.Switch(new EmployeesListView());
                }
                else
                {
                    Switcher.Switch(new FailedAuthorization());
                }
            });
        }
    }
}
