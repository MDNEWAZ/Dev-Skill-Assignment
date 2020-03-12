using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Miu.Library.Web.Areas.Admin.Models;

namespace Miu.Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }
    }
}