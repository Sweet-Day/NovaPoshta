using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.ViewModels
{
    public class NotificationListViewModel:BaseNotifyOfPropertyChanged
    {
        IRepository<Notification> _repository;
        public ObservableCollection<Notification> Notifications { get; set; }
        public string LoggedUser { get; set; } = $"{AuthenticationService.CurrentUser?.Name} {AuthenticationService.CurrentUser?.LastName}";
        public NotificationListViewModel()
        {
            _repository=new NotificationRepository();
            GetCurrentUserNotifications().Wait();
        }
        private Task GetCurrentUserNotifications()
        {
            return Task.Run(async () =>
            {
                if (AuthenticationService.CurrentUser != null)
                {
                    IQueryable<Notification> query = (await _repository
                        .GetAllAsync())
                        .Where(x => x.EmployeeId == AuthenticationService.CurrentUser.Id);
                    
                    Notifications = new ObservableCollection<Notification>(
                        query
                        .ToArray()
                        .Where(x=>DateTime.Now<x.DueTime)
                        .Take(4));
                }

            });
         
        }
    }
}
