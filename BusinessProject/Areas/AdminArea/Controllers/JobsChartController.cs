using AutoMapper;
using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.DbContext;
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
    public class JobsChartController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public JobsChartController(IUnitOfWork context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public IActionResult Index()
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
            ViewBag.JobJson = JsonConvert.SerializeObject(node);
            return View();
        }

        [HttpGet]
        public IActionResult AddJobsChart(int id, string parentname)
        {
            ViewBag.parentname = parentname;
            ViewBag.levelid = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddJobsChart(JobsChartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapModel = _mapper.Map<SystemJobs>(model);
                _context.JobanagerUW.Create(mapModel);
                _context.save();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditJobsChart(int id, string parentname)
        {
            if (id == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.parentname = parentname;
            
            var editModel = _context.JobanagerUW.GetById(id);
            var mapModel = _mapper.Map<JobsChartViewModel>(editModel);
            if (mapModel != null)
            {
                return View(mapModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditJobsChart(JobsChartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var jobsMapper = _mapper.Map<SystemJobs>(model);
                _context.JobanagerUW.Update(jobsMapper);
                _context.save();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

    }
}
