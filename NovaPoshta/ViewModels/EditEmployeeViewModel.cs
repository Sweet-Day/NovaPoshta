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
     
        public int SelectedPoshtomatIndex { get; set; } = 0;
        public string DateStr { get; set; }
        Employee currentEmployee;
        public Employee CurrentEmployee 
        { 
            get=>currentEmployee;

            set
            {
                currentEmployee = value;
                foreach (var item in Poshtomats) 
                {
                    if (item.Id != currentEmployee.PoshtomatId)
                    {
                        SelectedPoshtomatIndex += 1;
                    }
                    else break;
                }
                DateStr = currentEmployee.DateOfBirth.ToString("dd.MM.yyyy");
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
                CurrentEmployee.DateOfBirth = DateTime.Parse(DateStr);
                CurrentEmployee.PoshtomatId = Poshtomats[SelectedPoshtomatIndex].Id;
                employeeRepository.Update(CurrentEmployee);
                await employeeRepository.SaveChangesAsync();
                Switcher.Switch(new HomeView());
                HomeSwitcher.Switch(new EmployeesListView());
            },IsExecute);
        }
        private void UploadPoshtomats()
        {
            Poshtomats = new ObservableCollection<Poshtomat>(poshtomatRepository.GetAll());
        }
        private bool IsExecute(object obj)
        {
            if (SelectedPoshtomatIndex != -1)
            {
                DateTime res;
                if (DateTime.TryParse(DateStr, out res))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
