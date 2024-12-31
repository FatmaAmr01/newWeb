using System.Drawing;
using Fatma_Amr_W2_0523012.Models.Entitties;

namespace Fatma_Amr_W2_0523012.Models.ViewModel
{
    public class MemberAndProject
    {
        public string titel {  get; set; }
        public string description { get; set; }
        public int Memberid { get; set; }
        public ICollection<TeamMemer> teamMemers { get; set; }
        public int Projectid { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
