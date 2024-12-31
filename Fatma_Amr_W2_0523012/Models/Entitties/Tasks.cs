using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatma_Amr_W2_0523012.Models.Entitties
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskTitel { get; set; }
        public string TaskDescription{ get; set; }
        public string TaskStatue{ get; set; }
        public string TaskPriority{ get; set; }
        public DateTime Deadline{ get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int TeamMemberId { get; set; }
        [ForeignKey("TeamMemberId")]
        public TeamMemer TeamMemer {  get; set; }
    }
}
