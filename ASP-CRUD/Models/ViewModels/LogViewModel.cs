﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models;

namespace ASP_CRUD.Models.ViewModels
{
    public class LogViewModel
    {
        public List<Routine> Routines { get; set; }
        public int RoutineId { get; set; }
    }
}
