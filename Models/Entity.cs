using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace admin.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id{get;set;}
        [Required]
        [MaxLength(20)]
        public string CreatedBy{get;set;} = "admin";
        [MaxLength(20)]
        public string UpdatedBy{get;set;}
        [Required]
        public DateTime CreatedDate{get;private set;} = DateTime.UtcNow;
        public DateTime? UpdatedDate{get;private set;}
        public bool IsActive{get;set;} = false;
    }

    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName{get;set;}
        [MaxLength(500)]
        public string CategoryDesc{get;set;}
        public long? ParentCategoryId{get;set;}

        public Category ParentCategory{get;set;}

        [ForeignKey("ParentCategoryId")]
        public List<Category> Categories{get;set;}

        [ForeignKey("CategoryId")]
        public List<Course> Courses{get;set;}
    }

    public class Course:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string CourseName{get;set;}
        [MaxLength(1000)]
        public string CourseDesc{get;set;}
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OriginalPrice{get;set;}
        public TrainingMode Mode{get;set;}
        [MaxLength(500)]
        public string Keywords{get;set;}
        [MaxLength(500)]
        public string SEOTitle{get;set;}
        [MaxLength(1024)]
        public string CourseUrl{get;set;}
        [Required]
        [MaxLength(500)]
        public string Venue{get;set;}
        [ForeignKey("CourseId")]
        public List<CourseItem> CourseItems{get;set;}
        [ForeignKey("CourseId")]
        public List<CourseDiscount> Discounts{get;set;}

        public long CategoryId{get;set;}
        public Category CourseCategory{get;set;}

        public string Thumbnail{get;set;}
        public string BigImage{get;set;}
        public string VideoURL{get;set;}

    }

    public class CourseItem:BaseEntity
    {
        public long CourseId{get;set;}
        public Course MainCourse{get;set;}
        [MaxLength(500)]
        public string Keywords{get;set;}
        [Required]
        [MaxLength(500)]
        public string ItemTitle{get;set;}
        [MaxLength(1000)]
        public string ItemDesc{get;set;}
        public long? ParentCourseItemId{get;set;}
        [ForeignKey("ParentCourseItemId")]
        public List<CourseItem> Items{get;set;}
        
        public CourseItem ParentItem{get;set;}

        public string Thumbnail{get;set;}
        public string BigImage{get;set;}
        public string VideoURL{get;set;}
        
    }

    public class Discount:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string DiscountName{get;set;}
        [MaxLength(1000)]
        public string DiscountDesc{get;set;}
        [Required]
        [MaxLength(50)]
        public string DiscountCode{get;set;}

        [ForeignKey("DiscountId")]
        public List<CourseDiscount> Courses{get;set;}
    }


    public class CourseDiscount:BaseEntity
    {
        public long? CourseId{get;set;}
        public long? DiscountId{get;set;}

        public Course CourseObject{get;set;}
        public Discount DiscountObject{get;set;}
        [ForeignKey("CourseDiscountId")]
        public List<OrderItem> Orders{get;set;} 
    }

    public class Order:BaseEntity
    {
        [ForeignKey("OrderId")]
        public List<OrderItem> OrderItems{get;set;}
        [Required]
        [MaxLength(1000)]
        public string OrderDesc{get;set;}
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice{get;set;}
        public PaymentMode PaymentMode{get;set;}
        public long UserId{get;set;}
        public User UserEntity{get;set;}

    }

    public class OrderItem:BaseEntity
    {
        public long CourseId{get;set;}
        public int Quantity{get;set;}
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrderPrice{get;set;}
        public long? CourseDiscountId{get;set;}
        public CourseDiscount CourseDiscountApplied{get;set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OriginalPrice{get;set;}
        public long OrderId{get;set;}
        public Order MainOrder{get;set;}
    }

    public class User:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string UserName{get;set;}
        [Required]
        [MaxLength(100)]
        public string UserPassword{get;set;}
        [Required]
        [MaxLength(100)]
        public string FirstName{get;set;}
        [MaxLength(100)]
        public string LastName{get;set;}
        [Required]
        [MaxLength(100)]
        public string EmailId{get;set;}
        [MaxLength(20)]
        public string PhoneNo{get;set;}
        public UserRole UserRoleType{get;set;}

        public SocialUserType SocialLoginType{get;set;}

        [ForeignKey("UserId")]
        public List<Order> Orders{get;set;}

    }

    public enum UserRole
    {
        Admin = 0,
        User = 1
    }

    public enum SocialUserType
    {
        Facebook = 0,
        Google = 1
    }

    public enum TrainingMode
    {
        Online = 0,
        Offline = 1
    }

    public enum PaymentMode
    {
        Online = 0,
        Offline = 1
    }
}

