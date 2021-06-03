using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using admin.Models;
using Microsoft.AspNetCore.Http;

namespace admin.ViewModels
{
    public class CourseVM
    {
        public long Id{get;set;}
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

        [Required]
        public long CategoryId{get;set;}

        public IFormFile Thumbnail{get;set;}
        public IFormFile BigImage{get;set;}
        public string VideoURL{get;set;}
        public bool IsActive{get;set;}
    }
}

