using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models;

namespace ASP_CRUD.Models.ViewModels
{
    public class ActivityViewModel
    {
        public List<Activity> Activities { get; set; }
        public int Creator { get; set; }
        public string ActivityName { get; set; }
        public int Id { get; set; }
        public int ActivityId { get; set; } // used to target an activity for deletion
    }
}
