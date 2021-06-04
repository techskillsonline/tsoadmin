using admin.Data;
using admin.Models;
using admin.Services.Interfaces;

namespace admin.Services
{
    public class UserService:BaseService<User>,IUserService
    {
        public UserService(IBaseRepository<User> repo):base(repo)
        {
            
        }
        
    }
}
