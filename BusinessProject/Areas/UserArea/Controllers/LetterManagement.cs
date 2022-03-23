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

namespace BusinessProject.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class LetterManagement : Controller
    {
        private readonly IUploadFile _upload;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly UserManager<SystemUsers> _userManager;
        public LetterManagement(IUnitOfWork context,
                      UserManager<SystemUsers> userManager,
                      IUploadFile upload, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _upload = upload;
            _mapper = mapper;
        }
        public IActionResult CreateLetter()
        {
            return View();
        }

        public IActionResult UploadAttachFile(IEnumerable<IFormFile> filearray, string path, long filesize)
        {
            if (filesize >= 512000)
            {
                return Json(new { status = "badsize"});
            }
            var user = _context.userManagerUW.GetById(_userManager.GetUserId(HttpContext.User));
            string filename = _upload.UploadAttachFileFunc(filearray, path, user.UserName);
            return Json(new { status = "success", imagename = filename });
        }

        [HttpPost]
        
        public IActionResult CreateLetter(LettersViewModel model, string newfilePathName)
        {
            if (ModelState.IsValid)
            {
                model.LetterCreatDate = DateTime.Now;
                if (model.replayDateStatus == 1)
                {
                    model.ReplyDate = model.ReplyDate;
                }
                if (model.AttachmentStatus == 1)
                {
                    model.AttachmentFile = newfilePathName;
                }
                model.UserId = _userManager.GetUserId(HttpContext.User);
                _context.letterUW.Create(_mapper.Map<Letter>(model));
                _context.save();
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult SearchInSubject(string term)
        {
            try
            {
                var query = _context.adminstrativeFormUW.GetEntities(ad => ad.AdminstrativeFormTitle.Contains(term) &&
                            ad.UserId == _userManager.GetUserId(HttpContext.User)).Select(ad => ad.AdminstrativeFormTitle).ToList();
                return Ok(query);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
         public IActionResult DefaultForms()
        {
            var model = _context.adminstrativeFormUW.GetEntities(ad => ad.AdminstrativeFormType == false && ad.UserId == _userManager.GetUserId(HttpContext.User)).ToList();
            return PartialView("_defaultForms", model);
        }


        [HttpGet]
        public IActionResult AdminForms()
        {
            var model = _context.adminstrativeFormUW.GetEntities(ad => ad.AdminstrativeFormType == true).ToList();
            return PartialView("_adminForms", model);
        }
    }
}
