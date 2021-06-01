using admin.Data;
using admin.Models;

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
    }
}

