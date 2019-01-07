using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models;
using ASP_CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CRUD.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            var avm = new ActivityViewModel();
            avm.Activities = ActivityRepository.GetActivities();

            return View(avm);
        }

        public IActionResult CreateActivity(int Creator, string ActivityName)
        {
            var a = new Activity()
            {
                Creator = Creator,
                ActivityName = ActivityName
            };

            ActivityRepository.CreateActivity(a);
            return RedirectToAction("Index", "Activities");
        }

        public IActionResult DeleteActivity(int ActivityId)
        {
            // Need to check if Activity is being used in a routine before deleting
            try
            {
                ActivityRepository.DeleteActivity(ActivityId);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return RedirectToAction("Index", "Activities");
        }

        public IActionResult UpdateActivity(int Id, string ActivityName)
        {
            var a = new Activity()
            {
                Id = Id,
                Creator = 1,
                ActivityName = ActivityName
            };

            ActivityRepository.UpdateActivity(a);
            return RedirectToAction("Index", "Activities");
        }
    }
}