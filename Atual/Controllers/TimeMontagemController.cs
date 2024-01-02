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

    public class TimeMontagemController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly ITimeMontadoresService _timeMontadoresService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelFuncionarios;
        public TimeMontagemController(IUserService userService, ITimeMontadoresService timeMontadoresService) : base(userService, timeMontadoresService)
        {
            //_logger = logger;
            _userService = userService;
            _timeMontadoresService = timeMontadoresService;
        }

        [HttpPost("api/v1/TimeMontagem/create")]
        public IActionResult CreateTimeMontagem([FromBody] TimeMontadores TimeMontagem)
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
            TimeMontagem.Id = Guid.NewGuid();
            TimeMontagem.CompanyId = companyId;
            TimeMontagem = _timeMontadoresService.Add(TimeMontagem);

            if (TimeMontagem != null)
                return Ok(TimeMontagem);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001B - Error on try insert TimeMontagem"
                });
        }


        [HttpGet("api/v1/TimeMontagem/GetTimeMontagem")]
        public IActionResult GetTimeMontagem([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002A - Security Error - Access denied"
                });

            var TimeMontagem = _timeMontadoresService.Get(id);
            var companyId = new UtilsController(_userService).GetCompany();

            if (TimeMontagem != null && TimeMontagem.CompanyId == companyId)
                return Ok(TimeMontagem);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read client"
                });

        }


        [HttpGet("api/v1/TimeMontagem/GetTimeMontagems")]
        public IActionResult GetTimeMontagems()
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

            var TimeMontagems = _timeMontadoresService.GetAll(companyId);

            if (TimeMontagems != null)
                return Ok(TimeMontagems);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read TimeMontagems"
                });
        }


        [HttpPut("api/v1/TimeMontagem/Update")]
        public IActionResult UpdateTimeMontagem([FromBody] TimeMontadores TimeMontagem)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || TimeMontagem.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004A - Security Error - Access denied"
                });

            

            TimeMontagem = _timeMontadoresService.Update(TimeMontagem);

            if (TimeMontagem != null)
                return Ok(TimeMontagem);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004B/Sec - Error on try read client"
                });
        }


        [HttpDelete("api/v1/TimeMontagem/Delete")]
        public IActionResult DeleteTimeMontagem([FromBody] TimeMontadores TimeMontagem)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || TimeMontagem.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            

            if (TimeMontagem != null)
            {
                _timeMontadoresService.Delete(TimeMontagem);
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
