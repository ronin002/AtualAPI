using Atual.Data.InterfacesRepo;
using AtualAPI.Dtos;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class RoleUserRepo : IRoleUser
    {
        DataContext _context { get; set; }
        //private ILogsService LogsService { get; set; }
        public RoleUserRepo(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool AddRoleToUser(Role role, UserModel user)
        {
            throw new NotImplementedException();
        }

        public RoleUser GetRoleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<RoleUser> GetRolesCompany(Guid companyId)
        {
            return _context.RoleUsers.Where(x => x.companyId == companyId).ToList();
        }

        public List<RoleUser> GetRoleUser(Guid IdUser)
        {
            return _context.RoleUsers.Where(x => x.userId == IdUser).ToList();
        }

        public bool Remove(RoleUser role)
        {
            throw new NotImplementedException();
        }

        public bool Save(RoleUser role)
        {
            throw new NotImplementedException();
        }
    }
}
