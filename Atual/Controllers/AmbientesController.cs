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

    public class AmbientesController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IAmbienteService _ambienteService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelContrato;
        public AmbientesController(IUserService userService, IAmbienteService ambienteService) : base(userService, ambienteService)
        {
            //_logger = logger;
            _userService = userService;
            _ambienteService = ambienteService;
        }

        [HttpPost("api/v1/Ambientes/create")]
        public IActionResult CreateAmbientes([FromBody] Ambiente Ambiente)
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
            Ambiente.Id = Guid.NewGuid();
            Ambiente.CompanyId = companyId;
            Ambiente = _ambienteService.Add(Ambiente);

            if (Ambiente != null)
                return Ok(Ambiente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001B - Error on try insert Ambiente"
                });
        }


        [HttpGet("api/v1/Ambientes/GetAmbientes")]
        public IActionResult GetAmbientes([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002A - Security Error - Access denied"
                });

            var Ambiente = _ambienteService.Get(id);
            var companyId = new UtilsController(_userService).GetCompany();

            if (Ambiente != null && Ambiente.CompanyId == companyId)
                return Ok(Ambiente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read client"
                });

        }


        [HttpGet("api/v1/Ambientes/GetAmbientess")]
        public IActionResult GetAmbientess()
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

            var Ambientes = _ambienteService.GetAll(companyId);

            if (Ambientes != null)
                return Ok(Ambientes);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read Ambientess"
                });
        }


        [HttpPut("api/v1/Ambientes/Update")]
        public IActionResult UpdateAmbientes([FromBody] Ambiente ambiente)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || ambiente.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004A - Security Error - Access denied"
                });

            ambiente = _ambienteService.Update(ambiente);

            if (ambiente != null)
                return Ok(ambiente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004B/Sec - Error on try read client"
                });
        }


        [HttpDelete("api/v1/Ambientes/Delete")]
        public IActionResult DeleteAmbiente([FromBody] Ambiente ambiente)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || ambiente.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            

            if (ambiente != null)
            {
                _ambienteService.Delete(ambiente);
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
