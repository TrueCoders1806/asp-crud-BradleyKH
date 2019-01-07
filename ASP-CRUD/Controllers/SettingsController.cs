using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CRUD.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            var rvm = new RoutineViewModel();
            rvm.Routines = RoutineRepository.GetRoutines();
            return View(rvm);
        }
    }
}