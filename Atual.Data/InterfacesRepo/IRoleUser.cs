using AtualAPI.Dtos;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IRoleUser
    {

        List<RoleUser> GetRoleUser(Guid UserId);
        List<RoleUser> GetRolesCompany(Guid idCompany);
        RoleUser GetRoleById(Guid id);
        bool AddRoleToUser(Role role, UserModel user);
        bool Save(RoleUser role);
        bool Remove(RoleUser role);


    }
}
