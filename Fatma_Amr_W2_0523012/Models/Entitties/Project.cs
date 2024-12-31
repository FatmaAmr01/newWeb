using System.ComponentModel.DataAnnotations;

namespace Fatma_Amr_W2_0523012.Models.Entitties
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Tasks> tasks { get; set; }
    }
}
