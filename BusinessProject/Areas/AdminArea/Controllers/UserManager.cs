using AutoMapper;
using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class UserManager : Controller
    {
        private readonly IUploadFile _upload;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _context;
        private readonly UserManager<SystemUsers> _userManager;
        public UserManager(IUploadFile upload, UserManager<SystemUsers> userManager, IUnitOfWork context, IMapper mapper)
        {
            _upload = upload;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.userManagerUW.GetEntities();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserViewModel model,byte IsAdmin, byte Gender, string newImagePathName, string newSignaturePathName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // 
                    if (await _userManager.FindByNameAsync(model.UserName) != null)
                    {
                        ModelState.AddModelError("UserName", "نام کاربری تکراری می باشد.");
                        return View(model);
                    }

                    var user = new SystemUsers
                    {
                        FirstName = model.FirstName,
                        Family = model.Family,
                        PersonalCode = model.PersonalCode,
                        MilliCode = model.MilliCode,
                        Salary = model.Salary,
                        Email = model.Email,
                        UserName = model.UserName,
                        Address = model.Address,
                        Birthday = model.Birthday,
                        Gender = Gender,
                        IsAdmin = IsAdmin,
                        RegisterDate = DateTime.Now,
                        UserImg = newImagePathName,
                        SignatureImg = newSignaturePathName,
                        IsActive = 1,
                        PhoneNumber = model.PhoneNumber
                    };
                    IdentityResult result = await _userManager.CreateAsync(user, "123@d_F");

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                }
                catch
                {
                    return RedirectToAction("ErrorView", "Home");
                }
            }
            return View(model);
        }


        public IActionResult UploadImageFile(IEnumerable<IFormFile> filearray, string path)
        {
            string filename = _upload.UploadFileFunc(filearray, path);
            return Json(new { status = "success", imagename = filename });
        }

        // for update
        [HttpGet]
        public IActionResult EditUser(string userId)
        {
            if (userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var user = _context.userManagerUW.GetById(userId);
            var mapUser = _mapper.Map<UserViewModel>(user);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserViewModel model, string newImagePathName, string newSignaturePathName)
        {
            model.UserImg = newImagePathName;
            model.SignatureImg = newSignaturePathName;
            if (ModelState.IsValid)
            {
                //update
                var user = await _userManager.FindByIdAsync(model.Id);
                IdentityResult result = await _userManager.UpdateAsync(_mapper.Map(model, user));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "UserManager");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UserDetails(string userId)
        {
            var model = _context.userManagerUW.GetById(userId);
            return View(model);
        }

        [HttpGet]
        public IActionResult ActiveDeActiveUser(string Id, byte IsActive)
        {
            if (Id == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var user = _context.userManagerUW.GetById(Id);
            if (user == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }

            if (user.IsActive == 1)
            {
                // Should DeActivate
                ViewBag.theme = "darkred";
                ViewBag.ViewTitle = "To inactivate user";
                return PartialView("_ActiveOrDeActiveUser", user);

            }
            else
            {
                // Should Activate
                ViewBag.theme = "darkgreen";
                ViewBag.ViewTitle = "To activate user";
                return PartialView("_ActiveOrDeActiveUser", user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActiveDeActiveUserPost(string Id, byte IsActive)
        {
            if (Id == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            else
            {
                try
                {
                    if (IsActive == 1)
                    {
                        // DeActivate
                        var user = _context.userManagerUW.GetById(Id);
                        user.IsActive = 2;
                        _context.userManagerUW.Update(user);
                        _context.save();
                    }
                    else
                    {
                        // Activate
                        var user = _context.userManagerUW.GetById(Id);
                        user.IsActive = 1;
                        _context.userManagerUW.Update(user);
                        _context.save();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction("ErrorView", "Home");
                }
            }
        }

        [HttpGet]
        public IActionResult ChangePasswordbyAdmin(string userId, string FirstName, string Family)
        {
            if (userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.userId = userId;
            ViewBag.FullName = FirstName+ " " + Family;
            return PartialView("_ChangePasswordbyAdmin");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassByAdmin(ChangePasswordByAdminViewModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.userId);
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                var result = await _userManager.UpdateAsync(user);
                _context.save();
                return Json(new { status = "ok" });
            }
            catch
            {
                return Json(new { status = "error" });
            }
        }

    }
}
