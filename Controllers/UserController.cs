using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using admin.Services;
using admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class UserController:Controller
    {
        private readonly IUserService _usrsvc;

        public UserController(IUserService usrSvc)
        {
            this._usrsvc = usrSvc;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.UserStatus = "active";


            IEnumerable<User> lst = await _usrsvc.GetAsync();

            return View(lst);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.UserStatus = "active";

            return View(new User());
        }


        [HttpPost]
         public async Task<IActionResult> Add(User newUser)
        {
            ViewBag.UserStatus = "active";

            _usrsvc.Add(newUser);
            if(await _usrsvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(newUser);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long Id)
        {
            ViewBag.UserStatus = "active";

            User usr = await _usrsvc.GetByIdAsync(Id);

            return View(usr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User editUser)
        {
            ViewBag.UserStatus = "active";

            _usrsvc.Update(editUser);
            if(await _usrsvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(editUser);
        }

        public async Task<IActionResult> Delete(long Id)
        {
            ViewBag.UserStatus = "active";

            User usr = await _usrsvc.GetByIdAsync(Id);

            _usrsvc.Delete(usr);
            if(await _usrsvc.SaveChanges() >= 1)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
            
        }


    }
}
