using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task_app.Models
{
    public class GetTask_Result
    {
        public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Priority { get; set; }
		public DateTime CreateDate { get; set; }
    }
}