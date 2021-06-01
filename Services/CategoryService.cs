using System.Collections.Generic;
using System.Threading.Tasks;
using admin.Data;
using admin.Models;
using admin.Services.Interfaces;

namespace admin.Services
{
    public class CategoryService : BaseService<Category>,ICategoryService
    {
        public CategoryService(IBaseRepository<Category> repo):base(repo)
        {
            
        }
        
        public List<Category> GetSubCategories(long parentCategoryId)
        {
            return _repo.GetByFilter(i=>i.ParentCategoryId == parentCategoryId);
        }
    }
}

