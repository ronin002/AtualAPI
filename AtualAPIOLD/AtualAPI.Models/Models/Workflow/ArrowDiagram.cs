using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{
    public class ArrowDiagram
    {
        public Guid Id { get; set; }

        [ForeignKey("WorkFlow")]
        public Guid WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }

        public ArrowType ArrowType { get; set; }
        public string StartPoint { get; set; }
        public string LastPoint { get; set; }
        public string Points { get; set; }
        public string Origem { get; set; }
        public string OrigemGuid { get; set; }
        public string Destino { get; set; }
        public string DestinoGuid { get; set; }
        public string Value { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
