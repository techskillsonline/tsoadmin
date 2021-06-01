using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace admin.Services.Interfaces
{
    public interface IBaseService<T> where T:class
    {
        void Add(T newObj);
        void Update(T editObj);
        void Delete(T delObj);
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(long Id);

        Task<int> SaveChanges();
        List<T> GetByFilter(Func<T, bool> filter);
        
    }

}