using Atual.Models.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Models.Models
{
    public class Log
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public LogType Class { get; set; }
        public bool Uploaded { get; set; }
        public Guid SessionId { get; set; }
        public int UserId { get; set; }

        public Log()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.Now;
        }
    }
}
