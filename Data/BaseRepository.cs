using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using Microsoft.EntityFrameworkCore;

namespace admin.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T:BaseEntity
    {
        private readonly DatabaseContext _dbcontext;
        private readonly DbSet<T> _entity;
        public BaseRepository(DatabaseContext dbContext)
        {
            _dbcontext = dbContext;
            _entity = _dbcontext.Set<T>();
        }

        public void Add(T newObj)
        {
            _entity.Add(newObj);
        }

        public void Delete(T obj)
        {
            _entity.Remove(obj);
        }

        public async Task<List<T>> GetAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long Id)
        {
            return await _entity.SingleOrDefaultAsync(i=>i.Id == Id);
        }

        public List<T> GetByFilter(Func<T, bool> filter)
        {
            return _entity.Where(filter).ToList();
        }

        public void Update(T editObj)
        {
            editObj.UpdatedDate = DateTime.UtcNow;
            _entity.Update(editObj);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _entity.AsQueryable<T>();
        }
    }
}

