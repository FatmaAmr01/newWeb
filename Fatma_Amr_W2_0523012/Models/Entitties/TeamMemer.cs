using System.ComponentModel.DataAnnotations;

namespace Fatma_Amr_W2_0523012.Models.Entitties
{
    public class TeamMemer
    {
        [Key]
        public int TeamMemberId { get; set; }
        public string TeamMemerName { get; set; }
        public string TeamMemerEmail { get; set; }
        public string TeamMemerRple { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
