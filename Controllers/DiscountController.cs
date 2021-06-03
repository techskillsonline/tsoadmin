using System.Collections.Generic;
using System.Threading.Tasks;
using admin.Models;
using admin.Services;
using admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class DiscountController:Controller
    {
        private readonly IDiscountService _dissvc;

        public DiscountController(IDiscountService disSvc)
        {
            this._dissvc = disSvc;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.DiscountStatus = "active";

            IEnumerable<Discount> lst = await _dissvc.GetAsync();

            return View(lst);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.DiscountStatus = "active";

            return View(new Discount());
        }

        [HttpPost]
         public async Task<IActionResult> Add(Discount newDiscount)
        {
            ViewBag.DiscountStatus = "active";

            _dissvc.Add(newDiscount);
            if(await _dissvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(newDiscount);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long Id)
        {
            ViewBag.DiscountStatus = "active";

            Discount dis = await _dissvc.GetByIdAsync(Id);

            return View(dis);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Discount editDiscount)
        {
            ViewBag.DiscountStatus = "active";

            _dissvc.Update(editDiscount);
            if(await _dissvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(editDiscount);
        }

        public async Task<IActionResult> Delete(long Id)
        {
            ViewBag.DiscountStatus = "active";

            Discount dis = await _dissvc.GetByIdAsync(Id);

            _dissvc.Delete(dis);
            if(await _dissvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
            
        }
    }
}

