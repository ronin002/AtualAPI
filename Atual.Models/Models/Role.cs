
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Atual.Models.Enum;

namespace AtualAPI.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public ELevelAccess LevelCliente { get; set; }
        public ELevelAccess LevelContrato { get; set; }
        public ELevelAccess LevelFuncionarios { get; set; }
        public ELevelAccess LevelMontagens { get; set; }
        public ELevelAccess LevelUsers { get; set; }
        public ELevelAccess LevelRoles { get; set; }
        public ELevelAccess LevelAdmin { get; set; }
        public IList<Company> Companies { get; set; } 
        public IList<UserModel> Users { get; set; } 

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Role()
        {
            Companies = new List<Company>();
            Users = new List<UserModel>();
        }


    }
}
