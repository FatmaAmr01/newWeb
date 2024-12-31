using Fatma_Amr_W2_0523012.Models;
using Fatma_Amr_W2_0523012.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fatma_Amr_W2_0523012.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _app;
        public TasksController (AppDbContext dbContext)
        {
            _app= dbContext;
        }
        public IActionResult ShowTask()
        {
            var list = _app.Tasks.ToList();
            return View();
        }
        private readonly AppDbContext _dbContext;

      
        [HttpGet]
        public ActionResult Createtask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createtask(Tasks task)
        {
            if (task != null)
            {
                Tasks p = new Tasks()
                {
                    TaskTitel = task.TaskTitel,
                    Deadline = task.Deadline,
                    TaskDescription = task.TaskDescription,
                    TaskPriority = task.TaskPriority,
                    TaskStatue = task.TaskStatue,


                };
                _dbContext.Tasks.Add(p);
                _dbContext.SaveChanges();
                return RedirectToAction("Showtask");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Updatetask()
        {
            var listofT = _app.teamMemers.ToList();
            var listofP = _app.Projects.ToList();
            
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Updatetask(int id, Tasks task)
        {
            if (task != null)
            {
                var pro = _dbContext.Tasks.FirstOrDefault(x => x.ProjectId == id);
          
                _dbContext.Update(pro);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowTask");
            }
            else
            {
                return View();
            }


        }
        [HttpGet]
        public ActionResult DeleteTask(int id)
        {
            var p = _dbContext.Tasks.FirstOrDefault(x => x.TaskId == id);

            return View(p);
        }
        [HttpPost, ActionName("Deletetask")]
        public ActionResult DeleteConfirm(int Id)
        {
            var p = _dbContext.Tasks.FirstOrDefault(x => x.TaskId == Id);
            if (p != null)
            {
                _dbContext.Tasks.Remove(p);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowTask");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeteilsProjects(int Id, Tasks tasks)
        {
            var p = _dbContext.Tasks.FirstOrDefault(x => x.TaskId == Id);
            if (p != null)
            {
                return View(p);
            }

            return View();
        }
        //// GET: TasksController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: TasksController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TasksController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TasksController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TasksController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TasksController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TasksController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TasksController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
