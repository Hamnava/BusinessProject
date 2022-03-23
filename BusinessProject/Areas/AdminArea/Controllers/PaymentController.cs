using AutoMapper;
using BusinessProject.Core.Interfaces;
using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUserJobRepository _user;
        private readonly IMapper _mapper;
        public PaymentController(IUnitOfWork context, IUserJobRepository user, IMapper mapper)
        {
            _user = user;
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var model = _context.paymentUW.GetEntities(null, null,"User,Jobs");
            return View(model);
        }

        // for test
        public IActionResult ContractList()
        {
            var model = _context.contractUW.GetEntities(null, null, "User");
            return View(model);
        }

        [HttpGet]
        public IActionResult PaySalary(string FullName, int Salary, string Id)
        {
            // check if user has recieved his salary in this month
            var paymentdate = _user.GetPaymentDateFromUserID(Id);
            if (paymentdate != null)
            {
                var month = Convert.ToInt32(string.Format("{0:MM}", paymentdate.PaymentDate));
                if (month != 0)
                {
                    var DateNow = Convert.ToInt32(string.Format("{0:MM}", DateTime.Now));
                    if (month == DateNow)
                    {
                        //TempData["Datepay"] = datepay;
                        TempData["Date"] = 1;
                        return RedirectToAction("Index", "UserManager");
                    }
                }
            }
           
           
            ViewBag.FullName = FullName;
            ViewBag.Salary = Salary;
            ViewBag.userID = Id;
            ViewBag.JobID = _user.GetJobIdFromUserID(Id);
            ViewBag.JobName = _user.GetJobNameFromUserID(Id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PaySalary(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //add
                    var mapModel = _mapper.Map<Payment>(model);
                    mapModel.PaymentDate = DateTime.Now;
                    _context.paymentUW.Create(mapModel);
                    _context.save();
                    return RedirectToAction(nameof(Index));
                }
                catch 
                {
                    return RedirectToAction("ErrorView", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditPayment(int paymentId, string position, string FullName, int Salary)
        {
            if (paymentId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.FullName = FullName;
            ViewBag.position = position;
            ViewBag.Salary = Salary;
            var payment = _context.paymentUW.GetById(paymentId);
            var mapPayment = _mapper.Map<PaymentViewModel>(payment);
            return View(mapPayment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPayment(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payMent = _mapper.Map<Payment>(model);
                _context.paymentUW.Update(payMent);
                _context.save();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
