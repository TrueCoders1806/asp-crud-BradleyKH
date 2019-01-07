using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CRUD.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            var hvm = new HistoryViewModel();
            hvm.Logs = LogRepository.GetLogs();
            return View(hvm);
        }
    }
}