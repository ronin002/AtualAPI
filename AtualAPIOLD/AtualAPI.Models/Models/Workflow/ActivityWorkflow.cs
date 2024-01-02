using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{
    public class ActivityWorkflow
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public Guid WorkflowId { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreationDate { get; set; }

    }

}
