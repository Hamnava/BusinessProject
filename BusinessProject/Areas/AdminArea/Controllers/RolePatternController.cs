using AutoMapper;
using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Authorization;
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
    public class RolePatternController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _irr;
        public RolePatternController(IUnitOfWork context, IMapper mapper, IRoleRepository irr)
        {
            _context = context;
            _irr = irr;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_context.rolePatternUW.GetEntities());
        }

        [HttpGet] 
        public IActionResult AddRolePattern()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRolePattern(RolePatternViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapModel = _mapper.Map<RolePattern>(model);
                _context.rolePatternUW.Create(mapModel);
                _context.save();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int RolePatternId)
        {
            if (RolePatternId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
          return View(_mapper.Map<RolePatternViewModel>(_context.rolePatternUW.GetById(RolePatternId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RolePatternViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.rolePatternUW.Update(_mapper.Map<RolePattern>(model));
                _context.save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult GiveRolesToPattern(string RolePatternName, int RolePatternId)
        {
            if (RolePatternId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.RolePatternName = RolePatternName;
            ViewBag.RolePatternId = RolePatternId;
            ViewBag.Patternrole = _irr.GetRoleIdFromRolePatternId(RolePatternId);
            FillTreeView();
            return View();
        }

        private void FillTreeView()
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
            ViewBag.AddRoleJson = JsonConvert.SerializeObject(node);
        }

        [HttpPost]
        public IActionResult GiveRolesToPatternPost(string selectedItems, int RolePatternId)
        {
            using (var transaction = _context.BeginTrasaction())
            {
                try
                {
                    List<JsTreeModel> items = JsonConvert.DeserializeObject<List<JsTreeModel>>(selectedItems);
                    if (items.Count() == 0)
                    {
                        return Json(new { status = "noselected" });
                    }

                    // delete all Role form rolepattern Details
                    _context.rolePatternDetailsUW.DeleteByRange(rp => rp.RolePatternId == RolePatternId);

                    // Add new rols to RolePatternDetails
                    for (int i = 0; i < items.Count(); i++)
                    {
                        RolePatternDetails RolePD = new RolePatternDetails
                        {
                            RolePatternId = RolePatternId,
                            RoleId = items[i].id
                        };
                        _context.rolePatternDetailsUW.Create(RolePD);
                    }
                    transaction.Commit();
                    _context.save();
                    return Json(new { status = "success" });
                }
                catch
                {
                    transaction.RollBack();
                    return Json(new { status = "error" });
                }
            }
          
        }
    }
}
