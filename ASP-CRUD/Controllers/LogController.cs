using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CRUD.Models.ViewModels;
using Newtonsoft.Json.Linq;

namespace ASP_CRUD.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public IActionResult Index()
        {
            var lvm = new LogViewModel()
            {
                Routines = RoutineRepository.GetRoutines()
            };

            return View(lvm);
        }

        public IActionResult Record(int RoutineId)
        {
            var rlvm = new RecordLogViewModel();
            rlvm.SelectedRoutine = RoutineRepository.GetRoutineById(RoutineId);

            var activityIdList = JArray.Parse(rlvm.SelectedRoutine.Activities).ToObject<List<int>>();
            var activityList = new List<string>();

            for (int i = 0; i < activityIdList.Count; i++)
            {
                activityList.Add(ActivityRepository.GetActivityById(activityIdList[i]).ActivityName);
            }

            rlvm.ActivitiesList = activityList;
            return View(rlvm);
        }

        public IActionResult Save(int id)
        {
            return View();
        }

        /*
        // GET: Log/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Log/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Log/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Log/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Log/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Log/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}