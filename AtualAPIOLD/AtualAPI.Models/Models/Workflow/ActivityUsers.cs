using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{
    public class ActivityUsers
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; } 
        public ELevelAccess LevelAccess { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
