using NovaPoshta.Infrastrcture;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
using NovaPoshta.Views.Employees;
using NovaPoshta.Views.Login;
using NovaPoshta.Views.Notifications;
using NovaPoshta.Views.Poshtomats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    internal class HomeViewModel:BaseNotifyOfPropertyChanged,INavigator
    {
        UserControl currentHomePage;
        public ICommand EmployeesListCommand { get; set; }
        public ICommand PoshtomatsListCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NotificationsListCommand { get; set; }
        public UserControl CurrentHomePage
        {
            get
            {
                return currentHomePage;
            }
            set
            {
                currentHomePage= value;
                NotifyPropertyChanged();
            }
        }
        public HomeViewModel() {
            HomeSwitcher.ContentArea = this;

            //HomeSwitcher.Switch(new PoshtomatsListView());

            EmployeesListCommand = new RelayCommand((obj) =>
            {
                HomeSwitcher.Switch(new EmployeesListView());
            });
            PoshtomatsListCommand = new RelayCommand((obj) =>
            {
                HomeSwitcher.Switch(new PoshtomatsListView());
            });
            ExitCommand = new RelayCommand((obj) =>
            {
                AuthenticationService.CurrentUser = new BusinessLogic.Context.Employee();
                Switcher.Switch(new LoginView());
            });
            NotificationsListCommand = new RelayCommand((obj) =>
            {
                HomeSwitcher.Switch(new NotificationsListView());
            });
        }

        public void Navigate(UserControl page)
        {
           this.CurrentHomePage = page;
        }
    }
}
