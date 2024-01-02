using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IRole
    {

        List<Role> GetAll(Guid companyId);
        Role Get(Guid id);
        Role Add(Role funcionario);
        Role Update(Role funcionario);
        void Delete(Role funcionario);



    }
}
