using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CRUD.Models.ViewModels
{
    public class EditRoutineViewModel
    {
        public List<Activity> AllActivities { get; set; }
        public List<int> ActivitiesInRoutine { get; set; }
        public Routine CurrentRoutine { get; set; }
    }
}
