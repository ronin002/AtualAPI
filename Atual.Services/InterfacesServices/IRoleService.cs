using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IRoleService
    {
        
        List<Role> GetAll(Guid CompanyId);
        Role Get(Guid id);
        Role Add(Role role);
        Role Update(Role role);
        void Delete(Role role);
        

    }
}
