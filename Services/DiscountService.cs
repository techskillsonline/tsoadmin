using System.Collections.Generic;
using System.Threading.Tasks;
using admin.Data;
using admin.Models;
using admin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace admin.Services
{
    public class DiscountService:BaseService<Discount>,IDiscountService
    {
        public DiscountService(IBaseRepository<Discount> repo):base(repo)
        {
            
        }
    }

     public class CourseDiscountService:BaseService<CourseDiscount>,ICourseDiscountService
    {
        public CourseDiscountService(IBaseRepository<CourseDiscount> repo):base(repo)
        {
            
        }

        public async Task<List<CourseDiscount>> GetCourseAndDiscountEntitiesAsync()
        {
            return await _repo.GetQueryable().Include(i=>i.CourseObject).Include(j=>j.DiscountObject).ToListAsync();
        }
    }
}

