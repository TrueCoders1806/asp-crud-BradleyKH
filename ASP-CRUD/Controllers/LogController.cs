using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_CRUD.Models.ViewModels;

namespace ASP_CRUD.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Index()
        {
            var lvm = new LogViewModel();
            lvm.Logs = LogRepository.GetLogs();
            return View(lvm);
        }
    }
}