using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task_app.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string TaskInfo { get; set; }
        public string Pryority { get; set; }
    }
}