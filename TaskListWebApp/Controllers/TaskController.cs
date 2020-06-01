using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskListWebApp.Models;

namespace TaskListWebApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskListIdentityContext _context;

        public TaskController(TaskListIdentityContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var thisUsersTask = from n in _context.Task
                                where n.UserId == id
                                select n;

            return View(thisUsersTask);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Models.Task newTask)
        {
            if (ModelState.IsValid)
            {
                _context.Task.Add(newTask);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }
    }
}