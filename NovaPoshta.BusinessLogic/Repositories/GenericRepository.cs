using NovaPoshta.BusinessLogic.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private DbSet<T> table;
        public GenericRepository() 
        {
            context = new NovaPoshtaContext();
            table=context.Set<T>();
        }
        public void Create(T entity)
        {
            table.Add(entity);
        }

        public T Delete(T entity)
        {
            table.Remove(entity);
            return entity;
        }

        public T Get(Guid id)
        {
            return table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public T Update(T entity)
        {
            table.AddOrUpdate(entity);
            return entity;
        }

        public Task SaveChangesAsync()
        {
            return Task.Run(() =>
            {
                SaveChanges();
            });
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }
    }
}
