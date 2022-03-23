using AutoMapper;
using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class DefaultFormController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly UserManager<SystemUsers> _userManager;
        public DefaultFormController(IUnitOfWork context, UserManager<SystemUsers> userManager, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = _context.adminstrativeFormUW.GetEntities(ad => ad.UserId == _userManager.GetUserId(HttpContext.User) && ad.AdminstrativeFormType == false).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewDefaultForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewDefaultForm(AdminstrativeDefaultFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = _userManager.GetUserId(HttpContext.User);
                model.AdminstrativeFormType = false;
                var mapModel = _mapper.Map<AdminstrativeForm>(model);
                _context.adminstrativeFormUW.Create(mapModel);
                _context.save();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int AdminstrativeFormId)
        {
            if (AdminstrativeFormId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = _context.adminstrativeFormUW.GetById(AdminstrativeFormId);
            return PartialView("_DeleteDelfaultForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteForm(int AdminstrativeFormId)
        {
            try
            {
                _context.adminstrativeFormUW.DeleteById(AdminstrativeFormId);
                _context.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("ErrorView", "Home");
            }
        }
    }
}
