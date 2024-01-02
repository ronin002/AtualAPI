using Atual.Data.InterfacesRepo;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class RoleService : IRoleService
    {

        IRole _role { get; set; }
        //private ILogsService LogsService { get; set; }

        public RoleService(IRole role)
        {
            _role = role;
        }

        public List<Role> GetAll(Guid companyId)
        {
            return _role.GetAll(companyId);
        }

        public Role Get(Guid id)
        {
            return _role.Get(id);

        }

        public Role Add(Role role)
        {
            throw new NotImplementedException();
        }

        public Role Update(Role role)
        {
            throw new NotImplementedException();
        }

        public void Delete(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
