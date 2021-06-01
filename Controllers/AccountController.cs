using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using admin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace admin.Controllers
{
    public class AccountController:Controller
    {
        public object SignInAsync { get; private set; }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName,string userPassword)
        {
            if(!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(userPassword))
            {
                if(string.Equals(userName,"admin") && string.Equals(userPassword,"admin"))
                {
                    //Set Cookie
                    Claim nameclaim = new Claim(ClaimTypes.Name,userName);
                    Claim emailclaim = new Claim(ClaimTypes.Email,"rahulsinghishere@gmail.com");
                    Claim roleclaim = new Claim(ClaimTypes.Role,UserRole.Admin.ToString());

                    Claim[] claims = {nameclaim,emailclaim,roleclaim};

                    ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);

                    ViewBag.Message = $"Logged In as {userName}";
                    return RedirectToAction("Index","Home");

                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");

        }
    }
}

