using System.Collections.Generic;
using System.Threading.Tasks;
using admin.Models;

namespace admin.Services.Interfaces
{
    public interface ICourseService:IBaseService<Course>
    {
        public List<Course> GetCourseByCategory(long categoryId);
        public List<CourseItem> GetCourseItemsByCourse(long courseId);
        
    }
}

