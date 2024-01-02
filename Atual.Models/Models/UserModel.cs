using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        
        
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; } = Guid.Empty;

        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string? LastName { get; set; }
        public  string Cargo { get; set; }
        [JsonIgnore]
        public string Password { get; set; } = "";
        public List<Role> Roles { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public UserModel()
        {
            Roles = new List<Role>();
        }

    }
}
