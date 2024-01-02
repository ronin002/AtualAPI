
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace AtualAPI.Models 
{
    public class Funcionario 
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string? LastName { get; set; }
        public string Cargo { get; set; } = "";
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
