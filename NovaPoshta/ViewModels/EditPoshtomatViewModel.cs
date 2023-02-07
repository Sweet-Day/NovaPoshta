using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastrcture;
using NovaPoshta.Infrastructure;
using NovaPoshta.Views.HomeView;
using NovaPoshta.Views.Poshtomats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class EditPoshtomatViewModel
    {
        IRepository<Poshtomat> poshtomatRepository;
        public Poshtomat UpdatingPoshtomat { get; set; }
        public ICommand SavePoshtomatCommand { get; set; }

        public EditPoshtomatViewModel()
        {
            poshtomatRepository = new PoshtomatRepository();
            SavePoshtomatCommand = new RelayCommand(async (obj) =>
            {
                poshtomatRepository.Update(UpdatingPoshtomat);
                await poshtomatRepository.SaveChangesAsync();
                Switcher.Switch(new HomeView());
                HomeSwitcher.Switch(new PoshtomatsListView());
            });
        }
    }
}
