using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Context
{
    public class NovaPoshtaContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Poshtomat> Poshtomats { get; set; }
        public NovaPoshtaContext():
            base("NovaPoshta")
        {

        }
    }
}
