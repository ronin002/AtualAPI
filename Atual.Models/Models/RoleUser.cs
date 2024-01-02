
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace AtualAPI.Models
{
    public class RoleUser
    {
        [Key]
        public Guid Id { get; set; }
        public Guid companyId { get; set; }
        public Guid userId { get; set; }
        public Guid roleId { get; set; }

        public Company Company { get; set; }
        public Role Role { get; set; }
        public UserModel User { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
