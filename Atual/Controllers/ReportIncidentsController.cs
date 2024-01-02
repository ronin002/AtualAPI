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

    public class ReportIncidentsController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IReportIncidenteService _reportIncidenteService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelMontagens;
        public ReportIncidentsController(IUserService userService, IReportIncidenteService reportIncidenteService) : base(userService, reportIncidenteService)
        {
            //_logger = logger;
            _userService = userService;
            _reportIncidenteService = reportIncidenteService;
        }

        [HttpPost("api/v1/Incidente/create")]
        public IActionResult CreateIncidente([FromBody] ReportIncidente Incidente)
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
            Incidente.Id = Guid.NewGuid();
            Incidente.CompanyId = companyId;
            Incidente = _reportIncidenteService.Add(Incidente);

            if (Incidente != null)
                return Ok(Incidente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001B - Error on try insert Incidente"
                });
        }


        [HttpGet("api/v1/Incidente/GetIncidente")]
        public IActionResult GetIncidente([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002A - Security Error - Access denied"
                });

            var Incidente = _reportIncidenteService.Get(id);
            var companyId = new UtilsController(_userService).GetCompany();

            if (Incidente != null && Incidente.CompanyId == companyId)
                return Ok(Incidente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read client"
                });

        }


        [HttpGet("api/v1/Incidente/GetIncidentes")]
        public IActionResult GetIncidentes()
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

            var Incidentes = _reportIncidenteService.GetAll(companyId);

            if (Incidentes != null)
                return Ok(Incidentes);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read Incidentes"
                });
        }


        [HttpPut("api/v1/Incidente/Update")]
        public IActionResult UpdateIncidente([FromBody] ReportIncidente Incidente)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || Incidente.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004A - Security Error - Access denied"
                });

            
            Incidente = _reportIncidenteService.Update(Incidente);

            if (Incidente != null)
                return Ok(Incidente);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004B/Sec - Error on try read client"
                });
        }


        [HttpDelete("api/v1/Incidente/Delete")]
        public IActionResult DeleteIncidente([FromBody] ReportIncidente Incidente)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || Incidente.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            

            if (Incidente != null)
            {
                _reportIncidenteService.Delete(Incidente);
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
