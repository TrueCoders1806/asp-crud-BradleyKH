using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models;

namespace ASP_CRUD.Models.ViewModels
{
    public class RoutineViewModel
    {
        public List<Routine> Routines { get; set; }
        public int RoutineId { get; set; } // used to target a routine for deletion
        public int Id { get; set; }
        public int Creator { get; set; }
        public string RoutineName { get; set; }
        public string Activities { get; set; }
    }
}
