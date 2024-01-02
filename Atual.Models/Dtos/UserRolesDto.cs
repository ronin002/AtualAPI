using AtualAPI.Models;
using System.Globalization;

namespace AtualAPI.Dtos
{
    public class UserRoleBase
    {
        public int LevelProcess { get; set; }
        public int LevelDashBoard { get; set; }
        public int LevelAdmin { get; set; }
        public int LevelOperations { get; set; }
        public int LevelUsers { get; set; }
        public int LevelRoles { get; set; }
        public int LevelStations { get; set; }
        public int LevelWorkFlows { get; set; }
    }


    public class UserAndRole : UserRoleBase
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

    }



    public class UserRolesDto : UserRoleBase
    {
        public string Name { get; set; }
        
        public bool UseApi { get; set; }

    }

    public class AddRoleToUserDto
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }

}
