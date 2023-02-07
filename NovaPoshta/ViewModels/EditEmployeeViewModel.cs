using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastrcture;
using NovaPoshta.Infrastructure;
using NovaPoshta.Views.Employees;
using NovaPoshta.Views.HomeView;
using NovaPoshta.Views.Poshtomats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class EditEmployeeViewModel:BaseNotifyOfPropertyChanged
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
                poshtomats = value;
                NotifyPropertyChanged();
            }
        }
        Poshtomat selectedPoshtomat;
        public Poshtomat SelectedPoshtomat 
        {
            get => selectedPoshtomat;


            set
            {
                selectedPoshtomat = value;
                NotifyPropertyChanged();
            }
        }
        Employee currentEmployee;
        public Employee CurrentEmployee 
        { 
            get=>currentEmployee;

            set
            {
                UploadPoshtomats();
                currentEmployee = value;
                SelectedPoshtomat = currentEmployee.Poshtomat;
                NotifyPropertyChanged();
            } 
        
        }
        public ICommand SaveEmployeeCommand { get; set; }
        public EditEmployeeViewModel()
        {
            employeeRepository = new EmployeeRepository();
            poshtomatRepository = new PoshtomatRepository();
            UploadPoshtomats();
            SaveEmployeeCommand = new RelayCommand(async (obj) =>
            {
                employeeRepository.Update(CurrentEmployee);
                await employeeRepository.SaveChangesAsync();
                Switcher.Switch(new HomeView());
                HomeSwitcher.Switch(new EmployeesListView());
            });
        }
        private void UploadPoshtomats()
        {
            Poshtomats = new ObservableCollection<Poshtomat>(poshtomatRepository.GetAll());
        }

    }
}
