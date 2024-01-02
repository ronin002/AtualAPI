using Atual.Data.InterfacesRepo;
using Atual.Models.Dtos;
using Atual.Models.Enum;
using Atual.Services.Utils;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Atual.Controllers
{

    [ApiController]
    [Authorize]
    public class FuncionariosController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IFuncionarioService _funcionarioService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelFuncionarios;

        private UserSession _UserSection = new UserSession();
        public FuncionariosController(IUserService userService, IFuncionarioService funcionarioService) : base(userService, funcionarioService)
        {
            //_logger = logger;
            _userService = userService;
            _funcionarioService = funcionarioService;

            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //_UserSection = new UtilsController(_userService).GetUserSection(identity);



        }

        [Authorize]
        [HttpPost("api/v1/Funcionario/create")]
        public IActionResult CreateFuncionario([FromBody] CreateFuncDto funcionario)
        {
            var userSession = new UtilsController(_userService).GetUserSection(User);

            bool HasRole = false;
            if (userSession.UserLogged.Id == userSession.UserLoggedCompany.OwnerId)
                HasRole = true;
            else
                HasRole = new UtilsController(_userService).HasRoleIdentity(User, ELevelAccess.Add, ELocalTypeAccess);

            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001A - Security Error - Access denied"
                });

            var companyId = userSession.UserLoggedCompany.Id;
            Funcionario func = new Funcionario();
            func.Id = Guid.NewGuid();
            func.CompanyId = companyId;
            func.Email = funcionario.Email;
            func.Name = funcionario.Name;
            func.LastName = funcionario.LastName;
            func.Cargo = funcionario.Cargo;
            func = _funcionarioService.Add(func);

            if (funcionario != null)
                return Ok(func);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001B - Error on try insert Funcionario"
                });
        }

        [AllowAnonymous]
        [HttpGet("api/v1/Funcionario/GetFuncionariosTeste")]
        public IActionResult GetFuncionariosTeste()
        {
            Guid guidCompany = Guid.Parse("02078f0a-8d98-4f00-9420-d4ff3bfb06c4");
            var Funcionarios = _funcionarioService.GetAll(guidCompany);

            if (Funcionarios != null)
                return Ok(Funcionarios);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read Funcionarios"
                });
        }

        [HttpGet("api/v1/Funcionario/GetFuncionarios")]
        public IActionResult GetFuncionarios()
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

            var Funcionarios = _funcionarioService.GetAll(companyId);

            if (Funcionarios != null)
                return Ok(Funcionarios);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read Funcionarios"
                });
        }



        [HttpPut("api/v1/Funcionario/Update")]
        public IActionResult UpdateFuncionario([FromBody] Funcionario funcionario)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || funcionario.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004A - Security Error - Access denied"
                });



            funcionario = _funcionarioService.Update(funcionario);

            if (funcionario != null && funcionario.Id == companyId)
                return Ok(funcionario);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004B/Sec - Error on try read client"
                });
        }


        [HttpDelete("api/v1/Funcionario/Delete")]
        public IActionResult DeleteFuncionario([FromBody] Funcionario funcionario)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || funcionario.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            

            if (funcionario != null)
            {
                _funcionarioService.Delete(funcionario);
                return Ok();
            }
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read _funcionarioService"
                });
        }
    }
}
