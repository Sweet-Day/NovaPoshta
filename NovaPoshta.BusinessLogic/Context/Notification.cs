using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Context
{
    public class Notification
    {
        public Guid Id { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime StartTime { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [NotMapped]
        public string Header
        {
            get
            {
                TimeSpan time = DueTime - StartTime;
                return $"Заповніть поштомат через {time.Hours} годин";
            }
        }
        [NotMapped]
        public string Description
        {
            get
            {
                TimeSpan time = DueTime - StartTime;
                return $"Поштомат № {Employee.Poshtomat.Number} на вул... треба заповнити через {time.Hours} годин";
            }
        }
    }
}
