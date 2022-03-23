using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class AccessRightController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IRoleRepository _irr;
        private readonly UserManager<SystemUsers> _userManager;
        private readonly RoleManager<SystemRoles> _roleManager;
        public AccessRightController(IUnitOfWork context, 
                                      UserManager<SystemUsers> userManager,
                                       RoleManager<SystemRoles> roleManager,
                                             IRoleRepository irr)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _irr = irr;
        }


        public IActionResult Index()
        {
            var model = _context.userManagerUW.GetEntities();
            return View(model);
        }
        public IActionResult AddrRoleToUser(string userId, string FirstName, string Family)
        {

            ViewBag.FullName = FirstName + " " + Family;
            ViewBag.userId = userId;
            ViewBag.userRole = _irr.GetRoleId(userId);

            List<JsTreeModel> node = new List<JsTreeModel>();
            node.Add(new JsTreeModel
            {
                id = "1",
                text = "System Part",
                parent = "#"
            });

            foreach (SystemRoles role in _context.roleManagerUW.GetEntities(j => j.RoleLevel != "0"))
            {
                node.Add(new JsTreeModel
                {
                    id = role.Id,
                    parent = role.RoleLevel,
                    text = role.Name
                });
            }
            ViewBag.AddRoleJson = JsonConvert.SerializeObject(node);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(string userId, string selectedItems)
        {
            try
            {
                List<JsTreeModel> items = JsonConvert.DeserializeObject<List<JsTreeModel>>(selectedItems);
                if (items.Count() == 0)
                {
                    return Json(new { status = "noselected" });
                }
                // find user
                var user = await _userManager.FindByIdAsync(userId);
                // find roles
                var roles = await _userManager.GetRolesAsync(user);
                // delete all roles 
                IdentityResult deleteRoles = await _userManager.RemoveFromRolesAsync(user, roles);
                if (deleteRoles.Succeeded)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        SystemRoles sysRoles = await _roleManager.FindByIdAsync(items[i].id);
                        if (sysRoles != null)
                        {
                            await _userManager.AddToRoleAsync(user, sysRoles.Name);
                        }
                    }
                }

                return Json(new { status = "success" });
            }
            catch 
            {
                return RedirectToAction("ErrorView", "Home");
            }
          
        }

        [HttpGet]
        public IActionResult AddRoleToRolePattern(string userId, string FirstName, string Family)
        {
            ViewBag.FullName = FirstName + " " + Family;
            ViewBag.userId = userId;
            FillCombo();
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleToRolePattern(string userId, int RolePatternId)
        {
            if (RolePatternId == -1)
            {
                FillCombo();
                ViewBag.msg = "Please select one positon and then click save !";
                ViewBag.alert = "alert-danger";
                return View();
            }

            // find user
            var user = await _userManager.FindByIdAsync(userId);
            // find roles
            var roles = await _userManager.GetRolesAsync(user);
            // delete all roles 
            IdentityResult deleteRoles = await _userManager.RemoveFromRolesAsync(user, roles);

            // find Roles from pattern
            var getRoleFromPattern = _context.rolePatternDetailsUW.GetEntities(rp => rp.RolePatternId == RolePatternId, null, "Roles").ToList();
            if (deleteRoles.Succeeded)
            {
                for (int i = 0; i < getRoleFromPattern.Count(); i++)
                {
                    await _userManager.AddToRoleAsync(user, getRoleFromPattern[i].Roles.Name);
                }
            }
            FillCombo();
            ViewBag.msg = "The positioin has been given to user successfully !";
            ViewBag.alert = "alert-success";
            return View();
        }

        private void FillCombo()
        {
            List<RolePattern> rolePatternsList = _context.rolePatternUW.GetEntities().ToList();
            RolePattern Rp = new RolePattern
            {
                RolePatternId = -1,
                RolePatternName = "Please choose one position for this user!"
            };
            rolePatternsList.Insert(0, Rp);
            ViewBag.RolePatternList = rolePatternsList;
        }
    }
}
