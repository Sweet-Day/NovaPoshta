using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Context
{
    public class Poshtomat
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public int MaxQuantity { get; set; }
        public int CurrentQuantity { get; set; }
        [NotMapped]
        public string QuantityToString 
        {
            get
            {
                return $"{MaxQuantity}/{CurrentQuantity}";
            }
        }
        public override string ToString()
        {
            return Number;
        }
    }
}
