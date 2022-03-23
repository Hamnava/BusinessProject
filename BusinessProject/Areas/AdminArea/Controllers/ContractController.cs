using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class ContractController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<SystemUsers> _userManager;
        private readonly IUserJobRepository _user;
        public ContractController(IUnitOfWork context, UserManager<SystemUsers> userManager, IUserJobRepository user)
        {
            _context = context;
            _userManager = userManager;
            _user = user;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _user.GetContracts();
            return View(model);
        }
        public IActionResult UserList()
        {
            var model = _context.userManagerUW.GetEntities().OrderByDescending(u => u.Id).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddContract(string userId, string FullName)
        {

            var MyUserJob = _user.SeletTopOneUserJob(userId);
            /************ Check If User have a job or not***************/
            if (MyUserJob == null)
            {
                TempData["Contract"] = "Warning! this user doesn't have job, first give him a job and then make a contract";
                return RedirectToAction("UserList", "Contract");
            }

            /************************ Check if user currently have a job in system or not**************************/
            if (MyUserJob.IsHaveJob == false)
            {
                TempData["Contract"] = "Warning! this user doesn't have job, first give him a job and then make a contract";
                return RedirectToAction("UserList", "Contract");
            }

           /****************** Check if user already have a contract with this user or not* ***************/
            var myUsers = _context.contractUW.GetEntities(ul => ul.UserId == userId).ToList();
            if (myUsers.Count() != 0)
            {
                TempData["Contract"] = "You have already a contraction with this Employee, so please go to contract list, do a search and update that";
                return RedirectToAction("UserList", "Contract");
            }

            /*** Get Fullname and the job of user***/
            ViewBag.JobName = _user.GetJobNameFromUserID(userId);
            ViewBag.FullName = FullName;
            ViewBag.userId = userId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContract(ContractViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new Contract
                    {
                        UserId = model.UserId,
                        Position = model.Position,
                        EndDate = model.EndDate,
                        StartDate = model.StartDate,
                        ContractType = model.ContractType,
                        Currency = model.Currency,
                        GrossSalary = model.GrossSalary
                       
                    };
                   _context.contractUW.Create(user);
                   _context.save();
                    return RedirectToAction("Index");

                }
                catch
                {
                    return RedirectToAction("ErrorView", "Home");
                }
            }
            
            return View(model);
        }
        

        [HttpGet]
        public IActionResult EditContract(string FullName, int ContractId)
        {
            ViewBag.FullName = FullName;
            return View();
        }
    }
}
