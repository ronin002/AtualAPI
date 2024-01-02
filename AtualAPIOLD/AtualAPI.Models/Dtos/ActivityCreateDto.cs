using AtualAPI.Models.Workflow;
using AtualAPI.Models;

namespace AtualAPI.Dtos
{
    public class ActivityCreateDto
    {
        public string WorkFlowId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Location { get; set; }
        public string Center { get; set; }
        public int TypeActivity { get; set; }
        public string FileScript { get; set; }
        public byte[] Script { get; set; }
    }


}
