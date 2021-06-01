using System.Collections.Generic;
using System.Threading.Tasks;
using admin.Data;
using admin.Models;
using admin.Services.Interfaces;

namespace admin.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        //private readonly IBaseRepository<Course> _repo;
        private readonly IBaseRepository<CourseItem> _repoitems;

        public CourseService(IBaseRepository<Course> repo,IBaseRepository<CourseItem> repoItems):base(repo)
        {
            //this._repo = repo;
            this._repoitems = repoItems;
        }

        public List<Course> GetCourseByCategory(long categoryId)
        {
            return _repo.GetByFilter(i=>i.CategoryId == categoryId);
        }

        public List<CourseItem> GetCourseItemsByCourse(long courseId)
        {
            return _repoitems.GetByFilter(i=>i.CourseId == courseId);
        }
    }
}

