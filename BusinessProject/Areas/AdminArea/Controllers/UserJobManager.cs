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
    public class UserJobManager : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUserJobRepository _userJob;
        public UserJobManager(IUnitOfWork context, IUserJobRepository userjob)
        {
            _userJob = userjob;
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.userManagerUW.GetEntities();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddJobToUser(string userId, string FirstName, string Family)
        {

            List<JsTreeModel> node = new List<JsTreeModel>();

            node.Add(new JsTreeModel
            {
                id = "1",
                text = "CEO",
                parent = "#"
            });

            foreach (SystemJobs job in _context.JobanagerUW.GetEntities(j => j.JobsLevel != 0))
            {
                node.Add(new JsTreeModel
                {
                    id = job.JobsID.ToString(),
                    parent = job.JobsLevel.ToString(),
                    text = job.JobsName
                });
            }

            ViewBag.ReservJobToUser =
                JsonConvert.SerializeObject(_context.userJobUW.GetEntities(uj => uj.IsHaveJob == true).Select(uj => uj.JobId).ToList());

            ViewBag.FullName = FirstName + " " + Family;
            ViewBag.userId = userId;
            ViewBag.JobJson = JsonConvert.SerializeObject(node);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddJobToUser(UserJob model)
        {
            if (ModelState.IsValid)
            {
                UserJob Uj = new UserJob()
                {
                    IsHaveJob = true,
                    UserId = model.UserId,
                    JobId = model.JobId,
                    StartJobDate = DateTime.Now,
                };
                _context.userJobUW.Create(Uj);
                _context.save();
                //return View();
                return RedirectToAction("JobHistoryList", new { userId = model.UserId });
            }
            return RedirectToAction("JobHistoryList", new { userId = model.UserId });
        }

        [HttpGet]
        public IActionResult JobHistoryList(string userId)
        {
            if (userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = _context.userJobUW.GetEntities(uj => uj.UserId == userId, null, "Jobs");
            // check if user have job
            var checkForjob = model.Where(m => m.IsHaveJob == true).ToList();
            if (checkForjob.Count() > 0)
            {
                ViewBag.CheckJob = 1;
            }
            ViewBag.userId = userId;
            return View(model);
        }

        [HttpGet]
        public IActionResult DelJobFromUser(int UserJobId, string userId)
        {
            if (UserJobId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.UserJobId = UserJobId;
            ViewBag.userId = userId;
            return PartialView("_deljobfromUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelJobFromUserpost(int UserJobId, string userId)
        {
            if (UserJobId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            _userJob.DeleteJobFromUser(UserJobId);
            return RedirectToAction("JobHistoryList", new { userId = userId });
        }
    }
}
