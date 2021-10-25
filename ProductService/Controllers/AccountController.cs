using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductService.Business.Services.Interfaces;
using ProductService.Models;

namespace ProductService.Controllers
{
    public class AccountController : Controller
    {
        private ILoginService loginService;
        public AccountController(ILoginService service)
        {
            loginService = service;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterData data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var res = await loginService.Register(data);

            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(data);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginData data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var res = await loginService.Login(data);

            if (res.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(data);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await loginService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}