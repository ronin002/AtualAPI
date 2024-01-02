using AtualAPI.Data;
using AtualAPI.Dtos;
using AtualAPI.Models;
using AtualAPI.Models.Dtos;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;

namespace AtualAPI.Repository.Impl
{
    public class RoleRepositoryImpl : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public List<Role> GetRoleUser(Guid userId)
        {
            var company = _context.Companies.FirstOrDefault();
            if (company == null) return null;

            var companyId = company.Id;
            var rolesUsers = _context.RoleUsers.Where(ru => ru.userId == userId && ru.companyId == companyId).ToList();
            var allRoles = _context.Roles.Where(r => r.CompanyId == companyId).ToList();
            //var allRoles = _context.Roles.Where(r => rolesId.Contains(r.Id)).ToList();
            List<Role> roles = new List<Role>();
            foreach (Role role in allRoles)
            {
                if (rolesUsers.Where(ru => ru.roleId == role.Id).Count() > 0)
                    roles.Add(role);
            }
            return roles;
        }

        private bool UserHasRole(List<UserModel> users, Guid userId)
        {
            users.Where(u => u.Id == userId).ToList();
            return true;
        }
        public List<Role> GetRolesCompany(Guid idCompany)
        {
            return _context.Roles.Where(u => u.CompanyId == idCompany).ToList();
        }
        public List<UserModel> GetUsersWithThisRole(Role role)
        {
            var rolesId = _context.RoleUsers.Where(ru => ru.roleId == role.Id && ru.companyId == role.CompanyId);
            var allUsers = _context.Users.Where(u => rolesId.Any(ru => ru.userId == u.Id)).ToList();
            return allUsers;
            //var users = _context.Users.Where(x => x.Roles.Any(r => r.Id == role.Id)).ToList();
        }

        public Role GetRoleById(Guid idRole)
        {
            var role = _context.Roles.Where(u => u.Id == idRole).FirstOrDefault();

            if (role != null)
                return role;
            return null;
        }

        public bool AddRoleToUser(Role role, UserModel user)
        {
            var roleExists = _context.Roles.Any(x => x.CompanyId == role.CompanyId
                        && x.Id == role.Id);

            var userExists = _context.Users.Any(x => x.Id == user.Id);

            if (!roleExists || !userExists) //|| role.CompanyId != user.CompanyId)
            {
                return false;
            }

            RoleUser roleUser = new RoleUser();
            roleUser.Id = Guid.NewGuid();
            roleUser.companyId = role.CompanyId;
            roleUser.roleId = role.Id;
            roleUser.userId = user.Id;
            roleUser.CreationDate = DateTime.UtcNow;

            _context.RoleUsers.Add(roleUser);
            _context.SaveChanges();
            return true;
        }

        public bool Save(Role role)
        {
            var roleExists = _context.Roles.Where(x => x.CompanyId == role.CompanyId 
                        && x.Name == role.Name).FirstOrDefault();
            if (roleExists != null)
            {
                return false;
            }
            role.CreationDate = DateTime.UtcNow;
            _context.Roles.Add(role);
            _context.SaveChanges();
            return true;
        }

        public bool RemoveRoleToUser(Guid roleId, Guid userId)
        {
            var roleExists = _context.RoleUsers.Where(x => x.roleId == roleId && x.userId == userId).FirstOrDefault();
            if (roleExists == null)
            {
                return false;
            }
            _context.RoleUsers.Remove(roleExists);
            _context.SaveChanges();
            return true;
        }

        public bool Remove(Role role)
        {
            var roleHasUsers = _context.RoleUsers.Any(x => x.roleId == role.Id);
            if (roleHasUsers)
                return false;

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }
   


        public List<Role> ObjetctRoles(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public List<UserRolesDto> GetUserRolesold(Guid idUser)
        {
            var listRoles = new List<UserRolesDto>();
            /*
            using (MySqlConnection conn = new MySqlConnection(Globals._Conn))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_UserRoles", conn))
                {


                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //Se abre la conexión
                    conn.Open();
                    cmd.Parameters.AddWithValue("v_IdUser", idUser);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        var roleDto = new UserRolesDto();

                        roleDto.Id = dr.Field<int>("id");
                        roleDto.OwnerId = dr.Field<int>("OwnerId");
                        roleDto.CompanyId = dr.Field<int>("CompanyId");
                        roleDto.Name = dr.Field<string>("Name");


                        roleDto.LevelProcess = dr.Field<int>("LevelProcess");
                        roleDto.LevelShapes = dr.Field<int>("LevelShapes");
                        roleDto.LevelConnectors = dr.Field<int>("LevelConnectors");
                        roleDto.LevelOperations = dr.Field<int>("LevelOperations");
                        roleDto.LevelFluxogram = dr.Field<int>("LevelFluxogram");
                        roleDto.UseApi = dr.Field<bool>("UseApi");

                        listRoles.Add(roleDto);
                    }

                }
            }
            */
            return listRoles;
        }
    }
}
