using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.Model
{
    public class AuthenticationService
    {
        static IRepository<Employee> repository { get; set; }=new EmployeeRepository();
        public static Employee CurrentUser { get; set; }
      
        public static Employee Login(string login,string password)
        {
            CurrentUser=repository
                .GetAll()
                .FirstOrDefault(x => x.Login==login&&x.Password==password);
            return CurrentUser;
        }
        public static Task<Employee> LoginAsync(string login, string password)
        {
            return Task.Run(() =>
            {
                CurrentUser = repository
              .GetAll()
              .FirstOrDefault(x => x.Login == login && x.Password == password);
                return CurrentUser;
            });
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static string RandomPassword(int size = 0)
        {
            Random random= new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(random.Next(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
    }
}
