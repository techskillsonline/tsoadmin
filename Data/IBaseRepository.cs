using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;

namespace admin.Data
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        public void Add(T newObj);
       

        public void Delete(T obj);
       

        public Task<List<T>> GetAsync();
        

        public Task<T> GetByIdAsync(long Id);
        

        public List<T> GetByFilter(Func<T, bool> filter);
        

        public void Update(T editObj);

        Task<int> SaveChanges();

        public IQueryable<T> GetQueryable();
       
    }
}

