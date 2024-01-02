
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public ELevelAccess LevelProcess { get; set; }
        public ELevelAccess LevelDashBoard { get; set; }
        public ELevelAccess LevelAdmin { get; set; }
        public ELevelAccess LevelOperations { get; set; }
        public ELevelAccess LevelUsers { get; set; }
        public ELevelAccess LevelRoles { get; set; }
        public ELevelAccess LevelStations { get; set; }
        public ELevelAccess LevelWorkFlows { get; set; }
        public IList<Company> Companies { get; set; }
        public IList<UserModel> Users { get; set; }
        public bool UseApi { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


    }
}
