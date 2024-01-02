using Atual.Data.InterfacesRepo;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class RoleRepo : IRole
    {

        DataContext _context { get; set; }
        //private ILogsService LogsService { get; set; }
        public RoleRepo(DataContext dataContext)
        {
            _context = dataContext;
        }
        public List<Role> GetAll(Guid companyId)
        {
            return _context.Roles.Where(x => x.CompanyId == companyId).ToList();
        }

        public Role Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Role Add(Role role)
        {
            throw new NotImplementedException();
        }

        public Role Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }

        public void Delete(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
