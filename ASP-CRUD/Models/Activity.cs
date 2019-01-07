using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CRUD.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int Creator { get; set; }
        public string ActivityName { get; set; }
    }
}
