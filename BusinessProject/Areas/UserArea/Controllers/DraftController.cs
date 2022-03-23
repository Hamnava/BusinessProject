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

namespace BusinessProject.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class DraftController : Controller
    {
        private readonly ILetterRepository _letter;
        private readonly IUnitOfWork _context;
        private readonly UserManager<SystemUsers> _userManager;
        public DraftController(IUnitOfWork context, ILetterRepository letter, UserManager<SystemUsers> userManager)
        {
            _context = context;
            _letter = letter;
            _userManager = userManager;
        }

        private void TreeViewList()
        {

            List<JsTreeModel> node = new List<JsTreeModel>();

            node.Add(new JsTreeModel
            {
                id = "1",
                text = "مدیر عامل",
                parent = "#"
            });

            //foreach (JobsChart job in _context.jobsChartUW.GetEntities(j => j.JobsChartLevel != 0))
            foreach (JobsChartWithUserInfoViewModel job in _letter.JobsChartWithUserInfo())
            {
                node.Add(new JsTreeModel
                {
                    id = job.JobsID.ToString(),
                    parent = job.JobsLevel.ToString(),
                    text = job.JobsName + "(" + job.FirstName + " " + job.Family + ")"
                });
            }

            ViewBag.ReservJobToUser =
                JsonConvert.SerializeObject(_context.userJobUW.GetEntities(uj => uj.IsHaveJob == true).Select(uj => uj.JobId).ToList());

            //ViewBag.FullName = FirstName + " " + Family;
            //ViewBag.userId = userId;
            ViewBag.JobJson = JsonConvert.SerializeObject(node);
        }
        public IActionResult Index()
        {
            var model = _letter.LetterList(_userManager.GetUserId(HttpContext.User));
            ViewBag.JobIdList = JsonConvert.SerializeObject(_context.JobanagerUW.GetEntities().Select(j => j.JobsID).ToList());
            TreeViewList();
            ViewBag.userJobId = _context.userJobUW.GetEntities(u => u.UserId == _userManager.GetUserId(HttpContext.User) && u.IsHaveJob == true).Select(s => s.JobId).Single();
            return View(model);
        }


        //public IActionResult Index()
        //{
        //    var model = _letter.LetterList(_userManager.GetUserId(HttpContext.User));
        //    TreeViewCreator();
        //    ViewBag.UserJob =  _context.userJobUW.GetEntities(j=> j.UserId == _userManager.GetUserId(HttpContext.User) && j.IsHaveJob == true).Select(uj=> uj.JobId).Single();
        //    ViewBag.JobIdList = JsonConvert.SerializeObject(_context.JobanagerUW.GetEntities().Select(j => j.JobsID).ToList());
        //    return View(model);
        //}

        //private void TreeViewCreator()
        //{
        //    List<JsTreeModel> node = new List<JsTreeModel>();

        //    node.Add(new JsTreeModel
        //    {
        //        id = "1",
        //        text = "CEO",
        //        parent = "#"
        //    });

        //    //foreach (SystemJobs job in _context.JobanagerUW.GetEntities(j => j.JobsLevel != 0))
        //        foreach (JobsChartWithUserInfoViewModel job in _letter.JobsChartWithUserInfo())
        //        {
        //        node.Add(new JsTreeModel
        //        {
        //            id = job.JobsID.ToString(),
        //            parent = job.JobsLevel.ToString(),
        //            text = job.JobsName + "(" + job.FirstName + " " + job.Family + ")"
        //        });
        //    }

        //    ViewBag.ReservJobToUser =
        //        JsonConvert.SerializeObject(_context.userJobUW.GetEntities(uj => uj.IsHaveJob == true).Select(uj => uj.JobId).ToList());

        //    ViewBag.JobJson = JsonConvert.SerializeObject(node);

        //}
    }
}
