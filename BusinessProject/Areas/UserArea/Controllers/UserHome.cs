using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class UserHome : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
