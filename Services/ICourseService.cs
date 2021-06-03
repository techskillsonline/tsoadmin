using System.Collections.Generic;
using System.Threading.Tasks;
using admin.Models;
using admin.ViewModels;

namespace admin.Services.Interfaces
{
    public interface ICourseService:IBaseService<Course>
    {
        List<Course> GetCourseByCategory(long categoryId);
        List<CourseItem> GetCourseItemsByCourse(long courseId);

        Task<List<Course>> GetCourseCategory();
        Task<bool> Add(CourseVM newObj,string webRootPath);

        Task<bool> Edit(CourseVM newObj,string webRootPath);
        
    }
}

