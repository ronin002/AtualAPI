using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{
    public class GroupRows
    {
        public Guid Id { get; set; }

        [ForeignKey("Activity")]
        public Guid ActivityId { get; set; }
        //public virtual Activity Activity { get; set; }
        public string Text { get; set; }
        public Dictionary<string, string> Row { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }

}
