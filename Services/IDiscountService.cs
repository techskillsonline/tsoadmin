using System.Collections.Generic;
using System.Threading.Tasks;
using admin.Models;
using admin.Services.Interfaces;

namespace admin.Services.Interfaces
{
    public interface IDiscountService:IBaseService<Discount>
    {

    }

    public interface ICourseDiscountService:IBaseService<CourseDiscount>
    {
        Task<List<CourseDiscount>> GetCourseAndDiscountEntitiesAsync();
    }

    
}

