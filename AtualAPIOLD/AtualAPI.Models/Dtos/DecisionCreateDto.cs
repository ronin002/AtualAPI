using AtualAPI.Models.Workflow;
using AtualAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Dtos
{
    public class DecisionCreateDto
    {
        public string Id { get; set; }
        public string WorkFlowId { get; set; }
        public string Title { get; set; }
        public string GradientColor { get; set; }
        //public ElseIf ElseIF { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Location { get; set; }
        public string IFExpression { get; set; }

    }


}
