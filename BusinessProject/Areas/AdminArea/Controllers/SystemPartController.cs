using AutoMapper;
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
    public class SystemPartController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<SystemRoles> _roleManager;
        public SystemPartController(IUnitOfWork context, RoleManager<SystemRoles> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;
        }
        public IActionResult Index()
        {
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
            ViewBag.SystemPartJson = JsonConvert.SerializeObject(node);
            return View();
        }

        [HttpGet]
        public IActionResult AddSystemPart(string id, string parentname)
        {
            ViewBag.parentname = parentname;
            ViewBag.levelid = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSystemPart(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapModel = _mapper.Map<SystemRoles>(model);
                IdentityResult roleResult = await _roleManager.CreateAsync(mapModel);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
                return View(model);
        }
    }
}
