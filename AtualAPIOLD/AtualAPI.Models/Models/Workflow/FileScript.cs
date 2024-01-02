using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace AtualAPI.Models.Workflow
{
    [Table("file_script")]
    public class FileScript
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Activity")]
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public byte[] Script { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }

}
