using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
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
    public enum SortType
    {
        ByNumber,
        ByAddress,
        ByCapacity
    }
    public class PoshtomatsListViewModel:BaseNotifyOfPropertyChanged
    {
        IRepository<Poshtomat> poshtomatRepository;
        public Poshtomat SelectedPoshtomat { get; set; }
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
        public ICommand AddPoshtomatCommand { get; set; }
        public ICommand RemovePoshtomatCommand { get; set; }
        public ICommand UpdatePoshtomatCommand { get; set; }
        public ICommand SearchPoshtomatCommand { get; set; }
        public string SearchString { get; set; }
        public string LoggedUser { get; set; } = $"{AuthenticationService.CurrentUser?.Name} {AuthenticationService.CurrentUser?.LastName}";
        public PoshtomatsListViewModel()
        {
            poshtomatRepository=new PoshtomatRepository();
            Poshtomats=new ObservableCollection<Poshtomat>(poshtomatRepository.GetAll());
            InitCommand();
        }
        SortType sortType;
        public SortType SortType
        {
            get => sortType;
            set
            {
                sortType = value;
                SortPoshtomats();
                NotifyPropertyChanged();
            }
        }

        private void InitCommand()
        {
            AddPoshtomatCommand = new RelayCommand((obj) =>
            {
                Switcher.Switch(new AddPoshtomatView());

            });

            RemovePoshtomatCommand = new RelayCommand((obj) =>
            {
                if (SelectedPoshtomat != null)
                {
                    poshtomatRepository.Delete(SelectedPoshtomat);
                    poshtomatRepository.SaveChangesAsync();
                    Poshtomats.Remove(SelectedPoshtomat);
                }

            });
            UpdatePoshtomatCommand = new RelayCommand((obj) => {

                if (SelectedPoshtomat != null)
                {
                    UserControl updatingView = new EditPoshtomatView();
                    EditPoshtomatViewModel vm = new EditPoshtomatViewModel();
                    vm.UpdatingPoshtomat = SelectedPoshtomat;
                    updatingView.DataContext = vm;
                    Switcher.Switch(updatingView);
                }
                
            
            });
            SearchPoshtomatCommand = new RelayCommand((obj) =>
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    Poshtomats = new ObservableCollection<Poshtomat>(Poshtomats
                        .Where(x => x.Number.ToLower().Contains(SearchString.ToLower())));
                }
                else Poshtomats=new ObservableCollection<Poshtomat>(poshtomatRepository.GetAll());
            });
        }
        private void SortPoshtomats()
        {
            switch (SortType)
            {
                case SortType.ByNumber:
                    Poshtomats = new ObservableCollection<Poshtomat>(Poshtomats.OrderBy(x => x.Number));
                    break;
                case SortType.ByAddress:
                    Poshtomats = new ObservableCollection<Poshtomat>(Poshtomats.OrderBy(x => x.Address));
                    break;
                case SortType.ByCapacity:
                    Poshtomats = new ObservableCollection<Poshtomat>(Poshtomats.OrderBy(x => x.MaxQuantity-x.CurrentQuantity));
                    break;
            }
        }
    }
}
