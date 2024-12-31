using Fatma_Amr_W2_0523012.Models;
using Fatma_Amr_W2_0523012.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace Fatma_Amr_W2_0523012.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _dbContext;
        
        public ProjectController(AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public IActionResult ShowProjet()
        {
            var listofproject = _dbContext.Projects.ToList();
            return View(listofproject);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            if (project != null)
            {
                Project p = new Project()
                {
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription,
                    EndDate = project.EndDate,
                    StartDate = project.StartDate,

                };
                _dbContext.Projects.Add(p);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowProjet");
            }
            else
            {
                return View();
            }
        }

        public ActionResult UpdateProject()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (project != null)
            {
                var pro = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == id);
                pro.ProjectName = project.ProjectName;
                pro.ProjectDescription = project.ProjectDescription;
                pro.StartDate = project.StartDate;
                pro.EndDate = project.EndDate;
                pro.tasks = project.tasks;
                _dbContext.Update(pro);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowProjet");
            }
            else
            {
                return View();
            }
           

        }
        [HttpGet]
        public ActionResult DeleteProject(int id )
        {
            var p = _dbContext.Projects.FirstOrDefault(x=>x.ProjectId == id);

            return View(p);
        }
        [HttpPost, ActionName("DeleteProject")]
        public ActionResult DeleteConfirm(int Id)
        {
            var p = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == Id);
            if (p!= null)
            {
                _dbContext.Projects.Remove(p);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowProjet");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeteilsProjects(int Id , Tasks tasks)
        {           
                var p = _dbContext.Projects.FirstOrDefault(x=>x.ProjectId==Id);
                if (p!= null)
                {
                  return View(p);
                }
            
            return View();
        }
    }
}

