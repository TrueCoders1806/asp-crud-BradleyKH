using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models;
using ASP_CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ASP_CRUD.Controllers
{
    public class RoutineController : Controller
    {
        public IActionResult Index()
        {
            var rvm = new RoutineViewModel();
            rvm.Routines = RoutineRepository.GetRoutines();
            return View(rvm);
        }

        public IActionResult DeleteRoutine(int RoutineId)
        {
            RoutineRepository.DeleteRoutine(RoutineId);
            return RedirectToAction("Index", "Routine");
        }

        public IActionResult CreateRoutine(int Creator, string RoutineName, string Activities)
        {
            var r = new Routine()
            {
                Creator = Creator,
                RoutineName = RoutineName,
                Activities = Activities
            };

            RoutineRepository.CreateRoutine(r);
            return RedirectToAction("Index", "Routine");
        }

        public IActionResult Edit(int Id, int Creator, string RoutineName, string Activities)
        {
            var ervm = new EditRoutineViewModel();
            ervm.AllActivities = ActivityRepository.GetActivities();            
            ervm.CurrentRoutine = new Routine()
            {
                Id = Id,
                Creator = Creator,
                RoutineName = RoutineName,
                Activities = Activities
            };
			ervm.ActivitiesInRoutine = JArray.Parse(ervm.CurrentRoutine.Activities).ToObject<List<int>>();
			
            return View(ervm);
        }

        public IActionResult UpdateRoutine(int Id, string RoutineName, string Activities)
        {
            var r = new Routine()
            {
                Id = Id,
                Creator = 1,
                RoutineName = RoutineName,
                Activities = Activities                
            };

            RoutineRepository.UpdateRoutine(r);
            return RedirectToAction("Index", "Routine");
        }
    }
}