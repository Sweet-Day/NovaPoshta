using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T Delete(T entity);
        T Update(T entity);
        T Get(Guid id);
        IQueryable<T> GetAll();

        void SaveChanges();
        Task SaveChangesAsync();

        Task<IQueryable<T>> GetAllAsync();
    }
}
