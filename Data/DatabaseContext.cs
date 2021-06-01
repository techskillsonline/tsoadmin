using admin.Models;
using Microsoft.EntityFrameworkCore;

namespace admin.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions opts):base(opts)
        {
            
        }

        public DbSet<Course> Courses{get;set;}
        public DbSet<CourseItem> CourseItems{get;set;}

        public DbSet<Discount> Discounts{get;set;}
        public DbSet<CourseDiscount> CourseDiscounts{get;set;}
        public DbSet<Order> Orders{get;set;}

    }
}

