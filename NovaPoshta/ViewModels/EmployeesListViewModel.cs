using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
using NovaPoshta.Views.Employees;
using NovaPoshta.Views.Poshtomats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public enum SortEmployeeType
    {
        ByFullName,
        ByDateOfBirth,
        ByNumberPhone,
        ByPoshtomat
    }
    public class EmployeesListViewModel:BaseNotifyOfPropertyChanged
    {
        IRepository<Employee> _employeesRepository;
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand SearchEmployeeCommand { get; set; }
        public string SearchString { get; set; }
        public string LoggedUser { get; set; } = $"{AuthenticationService.CurrentUser?.Name} {AuthenticationService.CurrentUser?.LastName}";

        ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                NotifyPropertyChanged();
            }
        }
        public Employee SelectedEmployee { get; set; }
        SortEmployeeType sortType;
        public SortEmployeeType SortType
        {
            get => sortType;
            set
            {
                sortType = value;
                SortEmployees();
                NotifyPropertyChanged();
            }
        }
        public EmployeesListViewModel()
        {
            _employeesRepository = new EmployeeRepository();
            UploadEmployees();
            InitCommands();
        }



        private void InitCommands()
        {
            AddEmployeeCommand = new RelayCommand((obj) =>
            {
                Switcher.Switch(new AddEmployeeView());
            });
            RemoveEmployeeCommand = new RelayCommand(async (obj) =>
            {
                _employeesRepository.Delete(SelectedEmployee);
                await _employeesRepository.SaveChangesAsync();
                Employees.Remove(SelectedEmployee);

            }, (obj) => SelectedEmployee != null);
            UpdateEmployeeCommand = new RelayCommand((obj) =>
            {
                UserControl updatingView = new EditEmployeeView();
                EditEmployeeViewModel vm = new EditEmployeeViewModel();
                vm.CurrentEmployee = SelectedEmployee;
                updatingView.DataContext = vm;
                Switcher.Switch(updatingView);

            }, (obj) => SelectedEmployee != null);

            SearchEmployeeCommand = new RelayCommand((obj) =>
            {
                SearchEmployees();
            });
        }
        private async void UploadEmployees()
        {
            Employees = new ObservableCollection<Employee>(await _employeesRepository.GetAllAsync());
        }
        private void SortEmployees()
        {
            switch (SortType)
            {
                case SortEmployeeType.ByFullName:
                    Employees = new ObservableCollection<Employee>(Employees.OrderBy(x => x.FullName));
                    break;
                case SortEmployeeType.ByDateOfBirth:
                    Employees = new ObservableCollection<Employee>(Employees.OrderBy(x => x.DateOfBirth));
                    break;
                case SortEmployeeType.ByNumberPhone:
                    Employees = new ObservableCollection<Employee>(Employees.OrderBy(x => x.PhoneNumber));
                    break;
                case SortEmployeeType.ByPoshtomat:
                    Employees = new ObservableCollection<Employee>(Employees.OrderBy(x => x.Poshtomat.Number));
                    break;
            }
        }
        private async void SearchEmployees()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                Employees = new ObservableCollection<Employee>(
                    (await _employeesRepository.GetAllAsync())
                    .Where(x =>x.LastName.ToLower().Contains(SearchString.ToLower())) ) ;
            }
            else Employees =new ObservableCollection<Employee>(await _employeesRepository.GetAllAsync());
        }
    }
}
