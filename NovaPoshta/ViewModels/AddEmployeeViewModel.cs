using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastrcture;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
using NovaPoshta.Views.Employees;
using NovaPoshta.Views.HomeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class AddEmployeeViewModel:BaseNotifyOfPropertyChanged
    {
        IRepository<Employee> employeeRepository;
        IRepository<Poshtomat> poshtomatRepository;

        ObservableCollection<Poshtomat> poshtomats;
        public ObservableCollection<Poshtomat> Poshtomats 
        {
            get
            {
                return poshtomats;
            }
            set
            {
                poshtomats= value;
                NotifyPropertyChanged();
            } 
        }
        public Poshtomat SelectedPoshtomat { get; set; }
        public Employee NewEmployee { get; set; }
        public ICommand AddNewEmployeeCommand { get; set; }

        public string DateStr { get; set; }
       
        public AddEmployeeViewModel()
        {
            
            employeeRepository = new EmployeeRepository();
            poshtomatRepository = new PoshtomatRepository();
            NewEmployee = new Employee();
            UploadPoshtomats();
            AddNewEmployeeCommand = new RelayCommand(async (obj) =>
            {
                NewEmployee.DateOfBirth=DateTime.Parse(DateStr);
                NewEmployee.Id=Guid.NewGuid();
                NewEmployee.PoshtomatId=SelectedPoshtomat.Id;
                NewEmployee.Login = AuthenticationService.RandomString(6,false);
                NewEmployee.Password = AuthenticationService.RandomPassword();
                employeeRepository.Create(NewEmployee);
                await employeeRepository.SaveChangesAsync();
                Switcher.Switch(new HomeView());
                HomeSwitcher.Switch(new EmployeesListView());

            },IsExecute);
        }
        private bool IsExecute(object obj)
        {
            if (SelectedPoshtomat != null)
            {
                DateTime res;
                if (DateTime.TryParse(DateStr, out res))
                {
                    return true;
                }
            }
            return false;
        }
        private async void UploadPoshtomats()
        {
            Poshtomats=new ObservableCollection<Poshtomat>(await poshtomatRepository.GetAllAsync());
        }
    }
}
