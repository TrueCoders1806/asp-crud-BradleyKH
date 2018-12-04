using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CRUD.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int Creator { get; set; }
        public DateTime Date { get; set; }
        public int Activity { get; set; }
        public int Amount { get; set; }
    }
}
