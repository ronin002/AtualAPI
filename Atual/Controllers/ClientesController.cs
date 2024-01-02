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

    public class ClientesController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelCliente;
        public ClientesController(IUserService userService, IClientService clientService) : base(userService,clientService)
        {
            //_logger = logger;
            _userService = userService;
            _clientService = clientService;
        }

        [HttpPost("api/v1/cliente/create")]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
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
            cliente.Id = Guid.NewGuid();
            cliente.CompanyId = companyId;
            cliente = _clientService.Add(cliente);

            if (cliente != null)
                return Ok(cliente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001B - Error on try insert cliente"
                });
        }


        [HttpGet("api/v1/cliente/GetCliente")]
        public IActionResult GetCliente([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002A - Security Error - Access denied"
                });

            var cliente = _clientService.Get(id);
            var companyId = new UtilsController(_userService).GetCompany();

            if (cliente != null && cliente.CompanyId == companyId)
                return Ok(cliente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read client"
                });

        }


        [HttpGet("api/v1/cliente/GetClientes")]
        public IActionResult GetClientes()
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

            var clientes = _clientService.GetAll(companyId);

            if (clientes != null)
                return Ok(clientes);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read clientes"
                });
        }


        [HttpPut("api/v1/cliente/Update")]
        public IActionResult UpdateCliente([FromBody] Cliente cliente)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || cliente.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004A - Security Error - Access denied"
                });

            

            cliente = _clientService.Update(cliente);

            if (cliente != null && cliente.Id == companyId)
                return Ok(cliente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004B/Sec - Error on try read client"
                });
        }


        [HttpDelete("api/v1/cliente/Delete")]
        public IActionResult DeleteCliente([FromBody] Cliente cliente)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || cliente.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            

            if (cliente != null)
            {
                _clientService.Delete(cliente);
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
