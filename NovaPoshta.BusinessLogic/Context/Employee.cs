using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Context
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Guid PoshtomatId { get; set; }
        public virtual Poshtomat Poshtomat { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Notification> Notification { get; set; }=new HashSet<Notification>();

        [NotMapped]
        public string FullName
        {
            get => $"{LastName} {Name} {Patronymic}";
        }
    }
}
