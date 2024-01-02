using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{

    [Table("decisions")]
    public class Decision
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("WorkFlow")]
        public Guid WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }

        public string Title { get; set; }
        public string GradientColor { get; set; }
        //public ElseIf ElseIF { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Location { get; set; }
        public string IFExpression { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
