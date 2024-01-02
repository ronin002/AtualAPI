using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IRoleUserService
    {

        List<Role> GetRoleUser(UserModel user);
        List<Role> GetRolesCompany(Guid idCompany);
        Role GetRoleById(Guid id);
        bool AddRoleToUser(Role role, UserModel user);
        bool Save(Role role);
        bool Remove(Role role);


    }
}
