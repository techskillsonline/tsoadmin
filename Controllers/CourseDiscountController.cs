using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using admin.Services;
using admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class CourseDiscountController:Controller
    {
        private readonly ICourseDiscountService _cdsvc;
        private readonly ICourseService _crssvc;
        private readonly IDiscountService _dissvc;

        public CourseDiscountController(ICourseDiscountService cdSvc,ICourseService crsSvc,IDiscountService disSvc)
        {
            this._cdsvc = cdSvc;
            this._crssvc = crsSvc;
            this._dissvc = disSvc;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CourseDiscountStatus = "active";


            IEnumerable<CourseDiscount> lst = await _cdsvc.GetCourseAndDiscountEntitiesAsync();

            return View(lst);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.CourseDiscountStatus = "active";

            IEnumerable<KeyValuePair<string,string>> lstcourses = (await _crssvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),i.CourseName)
            ).ToList();

            IEnumerable<KeyValuePair<string,string>> lstdiscounts = (await _dissvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),$"{i.DiscountName}({i.DiscountCode})")
            ).ToList();

            ViewData["lstcourses"] = lstcourses;
            ViewData["lstdiscounts"] = lstdiscounts;

            return View(new CourseDiscount());
        }

        [HttpPost]
         public async Task<IActionResult> Add(CourseDiscount newDiscount)
        {
            ViewBag.CourseDiscountStatus = "active";

            _cdsvc.Add(newDiscount);
            if(await _cdsvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<KeyValuePair<string,string>> lstcourses = (await _crssvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),i.CourseName)
            ).ToList();

            IEnumerable<KeyValuePair<string,string>> lstdiscounts = (await _dissvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),$"{i.DiscountName}({i.DiscountCode})")
            ).ToList();

            ViewData["lstcourses"] = lstcourses;
            ViewData["lstdiscounts"] = lstdiscounts;

            return View(newDiscount);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long Id)
        {
            ViewBag.CourseDiscountStatus = "active";

            IEnumerable<KeyValuePair<string,string>> lstcourses = (await _crssvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),i.CourseName)
            ).ToList();

            IEnumerable<KeyValuePair<string,string>> lstdiscounts = (await _dissvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),$"{i.DiscountName}({i.DiscountCode})")
            ).ToList();

            ViewData["lstcourses"] = lstcourses;
            ViewData["lstdiscounts"] = lstdiscounts;

            CourseDiscount dis = await _cdsvc.GetByIdAsync(Id);

            return View(dis);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseDiscount editDiscount)
        {
            ViewBag.CourseDiscountStatus = "active";

            _cdsvc.Update(editDiscount);
            if(await _cdsvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<KeyValuePair<string,string>> lstcourses = (await _crssvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),i.CourseName)
            ).ToList();

            IEnumerable<KeyValuePair<string,string>> lstdiscounts = (await _dissvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),$"{i.DiscountName}({i.DiscountCode})")
            ).ToList();

            ViewData["lstcourses"] = lstcourses;
            ViewData["lstdiscounts"] = lstdiscounts;

            return View(editDiscount);
        }

        public async Task<IActionResult> Delete(long Id)
        {
            ViewBag.CourseDiscountStatus = "active";

            CourseDiscount dis = await _cdsvc.GetByIdAsync(Id);

            _cdsvc.Delete(dis);
            if(await _cdsvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
            
        }


    }
}