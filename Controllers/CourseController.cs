using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using admin.Services;
using admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        public CourseController(ICategoryService categorySvc,ICourseService courseSvc,IDiscountService discountSvc,ICourseDiscountService courseDiscountSvc)
        {
            this._categorysvc = categorySvc;
            this._coursesvc = courseSvc;
            this._discountsvc = discountSvc;
            this._coursediscountsvc = courseDiscountSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.CourseStatus = "active";

            IEnumerable<Course> lst = await _coursesvc.GetAsync();
            return View(lst);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["lstcategory"] = (await _categorysvc.GetAsync())
            .Select(i=>new KeyValuePair<string,string>(i.Id.ToString(),i.CategoryName)).ToList();

            ViewData["lstdiscounts"] = (await _discountsvc.GetAsync())
            .Select(j=>new KeyValuePair<string,string>(j.Id.ToString(),$"{j.DiscountName}({j.DiscountCode})")).ToList();

            return View(new Course());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Course newObj)
        {
            if(ModelState.IsValid)
            {
                _coursesvc.Add(newObj);
                if(await _coursesvc.SaveChanges() >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();

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
            Course crs = await _coursesvc.GetByIdAsync(Id);
            return View(crs);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course editObj)
        {
            if(ModelState.IsValid)
            {
                _coursesvc.Update(editObj);
                if(await _coursesvc.SaveChanges() >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
    }
}


