using Fatma_Amr_W2_0523012.Models;
using Fatma_Amr_W2_0523012.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fatma_Amr_W2_0523012.Controllers
{
    public class TeamMemberController : Controller
    {
        private AppDbContext _dbContext;
        public TeamMemberController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult ShowTeamMembers()
        {
            var listofmembers = _dbContext.teamMemers.ToList();
            return View(listofmembers);
        }
        [HttpGet]
        public ActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMember(TeamMemer team)
        {
            if (team != null)
            {
                TeamMemer T = new TeamMemer()
                {
                   TeamMemerName = team.TeamMemerName,
                   TeamMemerEmail = team.TeamMemerEmail,
                   TeamMemerRple = team.TeamMemerRple,
                   Tasks = team.Tasks

                };
                _dbContext.teamMemers.Add(T);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowTeamMembers");
            }
            else
            {
                return View();
            }
        }

        public ActionResult UpdatTeamMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatTeamMember(int id, TeamMemer te)
        {
            if (te != null)
            {
                var pro = _dbContext.teamMemers.FirstOrDefault(x => x.TeamMemberId == id);
                pro.TeamMemerRple = te.TeamMemerRple;
                pro.TeamMemerEmail = te.TeamMemerEmail;
                pro.TeamMemerRple = te.TeamMemerRple;
                pro.Tasks = te.Tasks;

                _dbContext.Update(pro);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowTeamMembers");
            }
            else
            {
                return View();
            }


        }
        [HttpGet]
        public ActionResult DeleteTeamMembers(int id)
        {
            var t = _dbContext.teamMemers.FirstOrDefault(x => x.TeamMemberId == id);

            return View(t);
        }
        [HttpPost, ActionName("DeleteTeamMembers")]
        public ActionResult DeleteConfirm(int Id)
        {
            var t = _dbContext.teamMemers.FirstOrDefault(x => x.TeamMemberId == Id);
            if (t != null)
            {
                _dbContext.teamMemers.Remove(t);
                _dbContext.SaveChanges();
                return RedirectToAction("ShowTeamMembers");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Deteilsteammembers(int Id)
        {

            var t = _dbContext.teamMemers.FirstOrDefault(x => x.TeamMemberId == Id);
            if (t != null)
            {
                return View(t);
            }

            return View();
        }
    }
}
