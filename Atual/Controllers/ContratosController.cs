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

    public class ContratosController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IContratoService _contratoService;
        private readonly IUserService _userService;

        public ContratosController(IContratoService contratoService, IUserService userService) : base(contratoService, userService)
        {
            //_logger = logger;
            _contratoService = contratoService;
            _userService = userService;
        }

        [HttpPost("api/v1/contrato/create")]
        public IActionResult CreateContrato([FromBody] Contrato contrato)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Add, ETypeAccess.LevelContrato);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7001A - Security Error - Access denied"
                });


            contrato = _contratoService.Add(contrato);

            if (contrato != null)
                return Ok(contrato);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7001B - Error on try insert contract"
                });
        }


        [HttpGet("api/v1/contrato/GetContrato")]
        public IActionResult GetContrato([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ETypeAccess.LevelContrato);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7002A - Security Error - Access denied"
                });

            var contrato = _contratoService.Get(id);

            if (contrato != null)
                return Ok(contrato);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7002B - Error on try read contract"
                });

        }


        [HttpGet("api/v1/contrato/GetContratos")]
        public IActionResult GetContratos()
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ETypeAccess.LevelContrato);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7003A - Security Error - Access denied"
                });

            var companyId = new UtilsController(_userService).GetCompany();

            var contratos = _contratoService.GetAll(companyId);

            if (contratos != null)
                return Ok(contratos);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7002B - Error on try read contract"
                });
        }


        [HttpPut("api/v1/contrato/Update")]
        public IActionResult UpdateContrato([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ETypeAccess.LevelContrato);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7004A - Security Error - Access denied"
                });

            var companyId = new UtilsController(_userService).GetCompany();

            var contrato = _contratoService.Get(id);

            if (contrato != null && contrato.Id == companyId)
                return Ok(contrato);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7004B/Sec - Error on try read contract"
                });
        }


        [HttpDelete("api/v1/contrato/Delete")]
        public IActionResult DeleteContratos()
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ETypeAccess.LevelContrato);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7003A - Security Error - Access denied"
                });

            var companyId = new UtilsController(_userService).GetCompany();

            var contrato = _contratoService.Get(companyId);

            if (contrato != null)
            {
                _contratoService.Delete(contrato);
                return Ok();
            }
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CTE7002B - Error on try read contract"
                });
        }
    }
}
