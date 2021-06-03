using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using admin.Services;
using admin.Services.Interfaces;
using admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class CourseController:Controller
    {
        private readonly ICategoryService _categorysvc;
        private readonly ICourseService _coursesvc;
        private readonly IDiscountService _discountsvc;
        private readonly ICourseDiscountService _coursediscountsvc;
        private readonly IWebHostEnvironment _env;

        public CourseController(ICategoryService categorySvc,ICourseService courseSvc,IDiscountService discountSvc,ICourseDiscountService courseDiscountSvc,IWebHostEnvironment env)
        {
            this._categorysvc = categorySvc;
            this._coursesvc = courseSvc;
            this._discountsvc = discountSvc;
            this._coursediscountsvc = courseDiscountSvc;
            this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.CourseStatus = "active";

            IEnumerable<Course> lst = await _coursesvc.GetCourseCategory();
            return View(lst);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["lstcategory"] = (await _categorysvc.GetAsync())
            .Select(i=>new KeyValuePair<string,string>(i.Id.ToString(),i.CategoryName)).ToList();

            ViewData["lstdiscounts"] = (await _discountsvc.GetAsync())
            .Select(j=>new KeyValuePair<string,string>(j.Id.ToString(),$"{j.DiscountName}({j.DiscountCode})")).ToList();

            return View(new CourseVM());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseVM newObj)
        {
            
            if(ModelState.IsValid)
            {
                if(await _coursesvc.Add(newObj,_env.WebRootPath))
                {
                    RedirectToAction("Index");
                }

            }
            
           return await Add();

        }

        public async Task<IActionResult> Delete(long Id)
        {
            Course deleteobj = await _coursesvc.GetByIdAsync(Id);
            _coursesvc.Delete(deleteobj);
            if(await _coursesvc.SaveChanges() >= 1)
            {
                    return RedirectToAction(nameof(Index));
            }

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(long Id)
        {
             ViewData["lstcategory"] = (await _categorysvc.GetAsync())
            .Select(i=>new KeyValuePair<string,string>(i.Id.ToString(),i.CategoryName)).ToList();

            ViewData["lstdiscounts"] = (await _discountsvc.GetAsync())
            .Select(j=>new KeyValuePair<string,string>(j.Id.ToString(),$"{j.DiscountName}({j.DiscountCode})")).ToList();

            Course crs = await _coursesvc.GetByIdAsync(Id);

            CourseVM cvm = new CourseVM
            {
                CategoryId = crs.CategoryId,
                CourseDesc = crs.CourseDesc,
                CourseName = crs.CourseName,
                CourseUrl = crs.CourseUrl,
                IsActive = crs.IsActive,
                Id = crs.Id,
                Keywords = crs.Keywords,
                Mode = crs.Mode,
                OriginalPrice = crs.OriginalPrice,
                SEOTitle = crs.SEOTitle,
                Venue = crs.Venue,
                VideoURL = crs.VideoURL,
                
            };

            return View(cvm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseVM newObj)
        {
            
            if(ModelState.IsValid)
            {
                if(await _coursesvc.Edit(newObj,_env.WebRootPath))
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            
           return await Edit(newObj.Id);

        }
    }
}


