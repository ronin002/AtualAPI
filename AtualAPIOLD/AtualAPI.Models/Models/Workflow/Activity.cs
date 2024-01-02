using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;


namespace AtualAPI.Models.Workflow
{
    public class Activity
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Location { get; set; }
        public string Center { get; set; }
        public ETypeActivity TypeActivity { get; set; }
        public string FileScript { get; set; }
        public string RowsJs { get; set; }
        public byte[] Script { get; set; }
       
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }

}
