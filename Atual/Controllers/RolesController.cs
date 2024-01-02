using Atual.Data.InterfacesRepo;
using Atual.Models.Enum;
using Atual.Services.Utils;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Security.Claims;

namespace Atual.Controllers
{

    [ApiController]

    public class RolesController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelRoles;
        public RolesController(IUserService userService, IRoleService roleService) : base(userService, roleService)
        {
            //_logger = logger;
            _userService = userService;
            _roleService = roleService;
        }

        [HttpPost("api/v1/Role/create")]
        public IActionResult CreateRole([FromBody] Role Role)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Add, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001A - Security Error - Access denied"
                });

            var companyId = new UtilsController(_userService).GetCompany();
            Role.Id = Guid.NewGuid();
            Role.CompanyId = companyId;
            Role = _roleService.Add(Role);

            if (Role != null)
                return Ok(Role);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001B - Error on try insert Role"
                });
        }


        [HttpGet("api/v1/Role/GetRole")]
        public IActionResult GetRole([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002A - Security Error - Access denied"
                });

            var Role = _roleService.Get(id);
            var companyId = new UtilsController(_userService).GetCompany();

            if (Role != null && Role.CompanyId == companyId)
                return Ok(Role);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read client"
                });

        }


        [HttpGet("api/v1/Role/GetRoles")]
        public IActionResult GetRoles()
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);

            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            var companyId = new UtilsController(_userService).GetCompany();

            var Roles = _roleService.GetAll(companyId);

            if (Roles != null)
                return Ok(Roles);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read Roles"
                });
        }


        [HttpPut("api/v1/Role/Update")]
        public IActionResult UpdateRole([FromBody] Role Role)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || Role.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004A - Security Error - Access denied"
                });

            

            Role = _roleService.Update(Role);

            if (Role != null && Role.Id == companyId)
                return Ok(Role);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004B/Sec - Error on try read client"
                });
        }


        [HttpDelete("api/v1/Role/Delete")]
        public IActionResult DeleteRole([FromBody] Role Role)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || Role.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            

            if (Role != null)
            {
                _roleService.Delete(Role);
                return Ok();
            }
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read client"
                });
        }
    }
}
