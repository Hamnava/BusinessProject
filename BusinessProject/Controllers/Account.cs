using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.DbContext;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Controllers
{
    public class Account : Controller
    {
        private readonly SignInManager<SystemUsers> _signInManager;
        public Account(SignInManager<SystemUsers> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/AdminArea/UserManager/Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Redirect("/AdminArea/UserManager/Index");
                }
                else
                {
                     ModelState.AddModelError("Password", "We don't have a user with this attributes");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Account/Login");
        }

    }
}
