using Atual.Data.ImplRepositories;
using Atual.Data.InterfacesRepo;
using Atual.Models.Enum;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Atual.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IAddressService _addressService;
        protected readonly IAmbienteService _ambienteService;
        protected readonly IClientService _clientService;
        protected readonly ICompanyService _companyService;

        protected readonly IContratoService _contratoService;
        protected readonly IFuncionarioService _funcionarioService;
        protected readonly IMontadoresService _montadoresService;
        protected readonly IMontagemService _montagemService;
        protected readonly IReportIncidenteService _reportIncidenteService;
        protected readonly IRoleService _roleService;
        protected readonly IRoleUserService _roleUserService;
        protected readonly ITimeMontadoresService _timeMontadoresService;
        protected readonly IUserService _userService;
        public UserSession BUserSection { get; set; }


        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        public BaseController(IContratoService contratoService, IUserService userService)
        {
            _userService = userService;
            _contratoService = contratoService;
        }

        public BaseController( IUserService userService, IClientService clientService)
        {
            _userService = userService;
            _clientService = clientService;
        }

        
         public BaseController(IUserService userService, ICompanyService companyService)
        {
            _userService = userService;
            _companyService = companyService;
        }
        public BaseController(IUserService userService, IAddressService addressService)
        {
            _userService = userService;
            _addressService = addressService;
        }

        public BaseController(IUserService userService, IAmbienteService ambienteService)
        {
            _userService = userService;
            _ambienteService = ambienteService;
        }

        public BaseController(IUserService userService, IFuncionarioService funcionarioService)
        {
            _userService = userService;
            _funcionarioService = funcionarioService;
        }

        public BaseController(IUserService userService, IMontadoresService montadoresService)
        {
            _userService = userService;
            _montadoresService = montadoresService;
        }

        public BaseController(IUserService userService, IMontagemService montagemService)
        {
            _userService = userService;
            _montagemService = montagemService;
        }

        public BaseController(IUserService userService, IReportIncidenteService reportIncidenteService)
        {
            _userService = userService;
            _reportIncidenteService = reportIncidenteService;
        }

        public BaseController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public BaseController(IUserService userService, ITimeMontadoresService timeMontadoresService)
        {
            _userService = userService;
            _timeMontadoresService = timeMontadoresService;
        }
        public BaseController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /*
        public virtual UserModel ReadToken()
        {
            var idUser = User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(x => x.Value).FirstOrDefault();
            if (!string.IsNullOrEmpty(idUser))
            {
                var user = new UserModel();
                user = _userService.Get(Guid.Parse(idUser));
                return user;
            }
            else
            {
                return null;
            }
            throw new UnauthorizedAccessException("Token invalid");
        }

        //[HttpGet("api/v1/GetUserLogged")]
        //[Route("api/[controller]")]
        public virtual UserModel GetUserLogged()
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
                return null;

            var name = identity.Name;
            var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();

            Guid guid = Guid.Empty;
            if (!Guid.TryParse(userId, out guid))
                return null;
            return _userService.Get(guid);
        }

        //[HttpGet("api/v1/GetcompanyUserLogged")]
        //[Route("api/[controller]")]
        public virtual Company GetcompanyUserLogged(UserModel userModel)
        {
            return _companyService.Get((Guid)userModel.CompanyId);
        }

        //[HttpGet("api/v1/HasRole")]
        //[Route("api/[controller]")]
        public virtual bool HasRole(ELevelAccess levelRequerido, ETypeAccess eTypeRequerido)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

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

            //If USERLOOGED AS OWNER
            var userLogged = GetUserLogged();
            var company = GetcompanyUserLogged(userLogged);
            if (company.OwnerId == userLogged.Id) return true;
            //var roleAccess = identity.FindFirst("sid").Value;
            //var rolesAccess = identity.FindFirst("role").Value;

            return false;
        }
        */
    }

    
}
