using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CRUD.Models.ViewModels
{
    public class RecordLogViewModel
    {
        public Routine SelectedRoutine { get; set; }
        public List<string> ActivitiesList { get; set; }

        public int Id { get; set; }
        public int Creator { get; set; }
        public string RoutineName { get; set; }
        public string Activities { get; set; }
    }

}
