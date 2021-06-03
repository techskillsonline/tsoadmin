using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.Data;
using admin.Models;
using admin.Services.Interfaces;

namespace admin.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T:BaseEntity
    {
        protected readonly IBaseRepository<T> _repo;

        public BaseService(IBaseRepository<T> repo)
        {
            this._repo = repo;
        }
        public void Add(T newObj)
        {
            _repo.Add(newObj);
        }

        public void Delete(T delObj)
        {
             _repo.Delete(delObj);
        }

        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.List<T>> GetAsync()
        {
            return await _repo.GetAsync();
        }

        public async System.Threading.Tasks.Task<T> GetByIdAsync(long Id)
        {
            return await _repo.GetByIdAsync(Id);
        }

        public void Update(T editObj)
        {
            _repo.Update(editObj);
        }

        public async Task<int> SaveChanges()
        {
            return await _repo.SaveChanges();
        }

        public List<T> GetByFilter(Func<T, bool> filter)
        {
            return _repo.GetByFilter(filter);
        }

        public IQueryable<T> GetQueryable()
        {
            return _repo.GetQueryable();
        }
    }
}



