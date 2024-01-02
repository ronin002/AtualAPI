using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{
    public class WorkFlow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; } 
        public IList<Activity> Activities { get; set; }
        public IList<Decision> Decisions { get; set; }
        public IList<ArrowDiagram> ArrowDiagrams { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
