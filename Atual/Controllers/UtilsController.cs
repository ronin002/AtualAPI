using Atual.Data.InterfacesRepo;
using Atual.Models.Enum;
using Atual.Services.Utils;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Atual.Controllers
{
    public class UtilsController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UtilsController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [HttpGet("api/v1/Utils/GetUserLogged")]
        public UserModel GetUserLogged(ClaimsPrincipal identity = null)
        {
            /*
            if (identity == null)
                identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
                return null;
            */
            if (identity == null)
                return null;


            var name = identity.Identity.Name;
            var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();

            Guid guid = Guid.Empty;
            if (!Guid.TryParse(userId, out guid))
                return null;
            return _userService.Get(guid);
        }

        [HttpGet("api/v1/Utils/GetcompanyUserLogged")]
        public Company GetCompanyUserLogged(UserModel userModel)
        {
            return _userService.GetCompany((Guid)userModel.CompanyId);
        }

        [HttpGet("api/v1/Utils/GetCompany")]
        public Guid GetCompany()
        {
            var user = GetUserLogged();
            if (user.CompanyId != Guid.Empty )
                return (Guid)user.CompanyId;

            return Guid.Empty;
        }

        [HttpGet("api/v1/Utils/HasRole")]
        public bool HasRole(ELevelAccess levelRequerido, ETypeAccess eTypeRequerido)
        {

            var identity = User;

            if (identity == null)
                return false;

            //IEnumerable<Claim> claims = identity.Claims;
            // or
            //string baseClain = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/";
            string baseClain = "http://schemas.microsoft.com/ws/2008/06/identity/claims/";



            var clains = User.Claims;
            foreach (var claim in clains)
            {
                if (claim.Type == baseClain + "sid")
                {

                }

                if (claim.Type == baseClain + "role")
                {
                    var roleClain = claim.Value;
                    if (!string.IsNullOrEmpty(roleClain))
                    {

                        List<Role> roles = new List<Role>();
                        try
                        {
                            roles = JsonConvert.DeserializeObject<List<Role>>(roleClain);
                        }
                        catch (Exception)
                        {
                            roles = null;
                            //throw;
                        }

                        if (roles != null)
                        {
                            foreach (Role role in roles)
                            {
                                switch (eTypeRequerido)
                                {

                                    case ETypeAccess.LevelCliente:
                                        if (role.LevelCliente >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelUsers:
                                        if (role.LevelUsers >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelContrato:
                                        if (role.LevelContrato >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelFuncionarios:
                                        if (role.LevelFuncionarios >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelMontagens:
                                        if (role.LevelMontagens >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelRoles:
                                        if (role.LevelRoles >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelAdmin:
                                        if (role.LevelAdmin >= levelRequerido)
                                            return true;
                                        break;
                                    default:
                                        break;

                                }

                            }
                        }

                        break;
                    }
                }
            }

            //If USERLOOGED AS OWNER
            var userLogged = GetUserLogged();
            var company = GetCompanyUserLogged(userLogged);
            if (company.OwnerId == userLogged.Id) return true;
            //var roleAccess = identity.FindFirst("sid").Value;
            //var rolesAccess = identity.FindFirst("role").Value;

            return false;
        }

        [HttpGet("api/v1/Utils/HasRoleIdentity")]
        public bool HasRoleIdentity(ClaimsPrincipal identity, ELevelAccess levelRequerido, ETypeAccess eTypeRequerido)
        {

            //var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            
            //IEnumerable<Claim> claims = identity.Claims;
            // or
            //string baseClain = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/";
            string baseClain = "http://schemas.microsoft.com/ws/2008/06/identity/claims/";



            var clains = identity.Claims;
            foreach (var claim in clains)
            {
                if (claim.Type == baseClain + "sid")
                {

                }

                if (claim.Type == baseClain + "role")
                {
                    var roleClain = claim.Value;
                    if (!string.IsNullOrEmpty(roleClain))
                    {

                        List<Role> roles = new List<Role>();
                        try
                        {
                            roles = JsonConvert.DeserializeObject<List<Role>>(roleClain);
                        }
                        catch (Exception)
                        {
                            roles = null;
                            //throw;
                        }

                        if (roles != null)
                        {
                            foreach (Role role in roles)
                            {
                                switch (eTypeRequerido)
                                {

                                    case ETypeAccess.LevelCliente:
                                        if (role.LevelCliente >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelUsers:
                                        if (role.LevelUsers >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelContrato:
                                        if (role.LevelContrato >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelFuncionarios:
                                        if (role.LevelFuncionarios >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelMontagens:
                                        if (role.LevelMontagens >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelRoles:
                                        if (role.LevelRoles >= levelRequerido)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelAdmin:
                                        if (role.LevelAdmin >= levelRequerido)
                                            return true;
                                        break;
                                    default:
                                        break;

                                }

                            }
                        }

                        break;
                    }
                }
            }
            return false;
        }



        [HttpGet("api/v1/Utils/GetUserSection")]
        public UserSession GetUserSection(ClaimsPrincipal ident)
        {

            var usename = ident.Identity.Name;
            
            var userId = ident.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();

            Guid guid = Guid.Empty;
            if (!Guid.TryParse(userId, out guid))
                return null;
            UserModel userLogged = _userService.Get(guid);

            var company = _userService.GetCompany(userLogged.CompanyId);

            UserSession userSection = new UserSession();
            userSection.UserLogged = userLogged;
            userSection.UserLoggedCompany = company;

            return userSection;

        }

    }
}
