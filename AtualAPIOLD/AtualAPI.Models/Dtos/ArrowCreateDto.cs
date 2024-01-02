using AtualAPI.Models.Workflow;
using AtualAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Dtos
{
    public class ArrowCreateDto
    {
        public string Id { get; set; }
        public string WorkFlowId { get; set; }
        public ArrowType ArrowType { get; set; }
        public string StartPoint { get; set; }
        public string LastPoint { get; set; }
        public string Points { get; set; }
        public string Origem { get; set; }
        public string OrigemGuid { get; set; }
        public string Destino { get; set; }
        public string DestinoGuid { get; set; }
        public string Value { get; set; }

    }


}
