using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class RoleUserService : IRoleUserService
    {
        IRoleUser _roleUser;
        IRole _role;

        public RoleUserService(IRoleUser roleUser, IRole role)
        {
            _roleUser = roleUser;
            _role = role;
        }
        public bool AddRoleToUser(Role role, UserModel user)
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(Guid id)
        {
            return _role.Get(id);
        }

        public List<Role> GetRolesCompany(Guid companyId)
        {
            return _role.GetAll(companyId);
        }

        public List<Role> GetRoleUser(UserModel user)
        {
            //var role = _roleUser.GetRoleUser(user.Id); // _context.Companies.FirstOrDefault();
            //if (role == null) return null;
            List<Role> roles = new List<Role>();
            if (user.CompanyId != Guid.Empty)
            {
                var companyId = user.CompanyId;
                var rolesUsers = _roleUser.GetRoleUser(user.Id); //_context.RoleUsers.Where(ru => ru.userId == userId && ru.companyId == companyId).ToList();
                var allRoles = _role.GetAll((Guid)user.CompanyId); //_context.Roles.Where(r => r.CompanyId == companyId).ToList();
                //var allRoles = _context.Roles.Where(r => rolesId.Contains(r.Id)).ToList();
                
                foreach (Role role in allRoles)
                {
                    if (rolesUsers.Where(ru => ru.Id == role.Id).Count() > 0)
                        roles.Add(role);

                    //if (rolesUsers.Where(ru => ru.roleId == role.Id).Count() > 0)
                    //     roles.Add(role);
                }
            }
            return roles;
        }

        public bool Remove(Role role)
        {
            throw new NotImplementedException();
        }

        public bool Save(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
