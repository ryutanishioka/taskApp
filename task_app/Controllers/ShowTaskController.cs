using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using task_app.Models;
using task_app.ViewModels;

namespace task_app.Controllers
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ShowTaskController : Controller
    {
        Task_db dbCon = new Task_db();

        
        public ActionResult TaskView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTasks()
        {
            //return Json(tasks, JsonRequestBehavior.AllowGet);
            List<GetTask_Result> getTaskList = dbCon.GetTask();
            List<TaskViewModel> taskList = new List<TaskViewModel>();
            foreach (var item in getTaskList)
            {
                TaskViewModel task = new TaskViewModel();
                task.Id = item.ID;
                task.TaskInfo = item.Description;
                task.Pryority = item.Priority.ToString();
                taskList.Add(task);
            }
            return Json(taskList, JsonRequestBehavior.AllowGet);
        }

        // POST: ShowTask/Create
        [HttpPost]
        public ActionResult AddTask(string taskName, string priority)
        {
            try
            {
                if (!string.IsNullOrEmpty(taskName))
                {
                    // 保存処理
                    int pri = int.Parse(priority);
                    bool boolTask = dbCon.CreateTask("testname", taskName, pri);
                    // データ取得処理
                    if (boolTask == true)
                    {
                        return Json(new { success = true });
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // POST: ShowTask/Edit
        [HttpPost]
        public ActionResult EditTask(int id, string taskName)
        {
            try
            {
                if (!string.IsNullOrEmpty(taskName))
                {
                    bool boolTask = dbCon.EditTask(id, taskName);
                    if (boolTask == true)
                    {
                        return Json(new { success = true });
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: ShowTask/Delete
        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            try
            {
                bool boolTask = dbCon.DeleteTask(id);
                if (boolTask == true)
                {
                    return Json(new { success = true });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
