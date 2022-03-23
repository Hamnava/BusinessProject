using BusinessProject.Core.Interfaces;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Areas.AdminArea.Component
{
    public class AdminInfo : ViewComponent
    {
        private readonly UserManager<SystemUsers> _userManager;
        private readonly IUnitOfWork _context;

        public AdminInfo(UserManager<SystemUsers> userManager, IUnitOfWork context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var model = _context.userManagerUW.GetById(_userManager.GetUserId(HttpContext.User));
            return View(model);
        }
    }
}
