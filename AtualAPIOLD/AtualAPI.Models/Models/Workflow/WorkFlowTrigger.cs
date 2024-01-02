using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{
    public class WorkFlowTrigger
    {
        public Guid Id { get; set; }
        public Guid WorkflowId { get; set; }
        public Guid TriggerId { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
