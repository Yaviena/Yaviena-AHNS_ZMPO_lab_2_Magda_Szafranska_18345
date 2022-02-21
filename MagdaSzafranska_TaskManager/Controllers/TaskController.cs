using MagdaSzafranska_TaskManager.Models;
using MagdaSzafranska_TaskManager.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagdaSzafranska_TaskManager.Controllers
{
    public class TaskController : Controller
    {
        /*
        private static IList<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel(){ TaskId = 1, Name = "Podlać kwiaty", Description = "W salonie i na balkonie", Done = false},
            new TaskModel(){ TaskId = 2, Name = "Dokumenty na wyjazd", Description = "Paszporty, dowody, zaświadczenia", Done = false},
        };*/

        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: Task
        public ActionResult Index()
        {
            // without saving in database:
            // return View(tasks.Where(x => !x.Done));
            return View(_taskRepository.GetAllActive());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            // without saving in database:
            // return View(tasks.FirstOrDefault(x => x.TaskId == id));
            return View(_taskRepository.Get(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            // without saving in database:
            // taskModel.TaskId = tasks.Count + 1;
            // tasks.Add(taskModel);

            _taskRepository.Add(taskModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            // without saving in database:
            // return View(tasks.FirstOrDefault(x => x.TaskId == id));
            return View(_taskRepository.Get(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            // without saving in database:
            // TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            // task.Name = taskModel.Name;
            // task.Description = taskModel.Description;

            _taskRepository.Update(id, taskModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            // without saving in database:
            // return View(tasks.FirstOrDefault(x => x.TaskId == id));
            return View(_taskRepository.Get(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            // without saving in database:
            // TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            // tasks.Remove(task);

            _taskRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Done/5
        public ActionResult Done(int id)
        {
            // without saving in database:
            // TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            TaskModel task = _taskRepository.Get(id);
            task.Done = true;
            _taskRepository.Update(id, task);

            return RedirectToAction(nameof(Index));
        }
    }
}
