using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class CategoryController:Controller
    {
        private readonly ICategoryService catsvc;

        public CategoryController(ICategoryService catsvc)
        {
            this.catsvc = catsvc;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryStatus = "active";

            IEnumerable<Category> lstcat = await catsvc.GetAsync();
            return View(lstcat);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<KeyValuePair<string,string>> lstcat = (await catsvc.GetAsync()).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),i.CategoryName)
            ).ToList();

            ViewData["KeyValue"] = lstcat;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category newObj)
        {
            if(ModelState.IsValid)
            {
                if(newObj.ParentCategoryId == -1)
                {
                    newObj.ParentCategoryId = null;
                }
                catsvc.Add(newObj);
                if(await catsvc.SaveChanges() >= 1)
                {
                    return RedirectToAction("Index");
                }
            }
            return await Add();

        }

        public async Task<IActionResult> Delete(long Id)
        {
            Category cattodelete = await catsvc.GetByIdAsync(Id);
            catsvc.Delete(cattodelete);
            if(await catsvc.SaveChanges() >= 1)
            {
                    return RedirectToAction("Index");
            }

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(long Id)
        {
            Category cat = await catsvc.GetByIdAsync(Id);

            IEnumerable<KeyValuePair<string,string>> lstcat = (await catsvc.GetAsync()).Where(i=>i.Id != Id).Select(i=>
                new KeyValuePair<string,string>(i.Id.ToString(),i.CategoryName)
            ).ToList();

            ViewData["KeyValue"] = lstcat;
            
            return View(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category editCategory)
        {
            if(ModelState.IsValid)
            {
                if(editCategory.ParentCategoryId == -1)
                {
                    editCategory.ParentCategoryId = null;
                }
                catsvc.Update(editCategory);
                if(await catsvc.SaveChanges() >= 1)
                {
                    return RedirectToAction("Index");
                }
            }
            return await Edit(editCategory.Id);
        }
    }
}


