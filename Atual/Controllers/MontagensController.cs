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

    public class MontagensController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMontagemService _montagemService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelMontagens;
        public MontagensController(IUserService userService, IMontagemService montagemService) : base(userService, montagemService)
        {
            //_logger = logger;
            _userService = userService;
            _montagemService = montagemService;
        }

        [HttpPost("api/v1/Montagem/create")]
        public IActionResult CreateMontagem([FromBody] Montagem montagem)
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
            montagem.Id = Guid.NewGuid();
            montagem.CompanyId = companyId;
            montagem = _montagemService.Add(montagem);

            if (montagem != null)
                return Ok(montagem);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7001B - Error on try insert Montagem"
                });
        }


        [HttpGet("api/v1/Montagem/GetMontagem")]
        public IActionResult GetMontagem([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002A - Security Error - Access denied"
                });

            var montagem = _montagemService.Get(id);
            var companyId = new UtilsController(_userService).GetCompany();

            if (montagem != null && montagem.CompanyId == companyId)
                return Ok(montagem);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read client"
                });

        }


        [HttpGet("api/v1/Montagem/GetMontagems")]
        public IActionResult GetMontagems()
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

            var Montagems = _montagemService.GetAll(companyId);

            if (Montagems != null)
                return Ok(Montagems);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7002B - Error on try read Montagems"
                });
        }


        [HttpPut("api/v1/Montagem/Update")]
        public IActionResult UpdateMontagem([FromBody] Montagem montagem)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || montagem.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004A - Security Error - Access denied"
                });



            montagem = _montagemService.Update(montagem);

            if (montagem != null )
                return Ok(montagem);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7004B/Sec - Error on try read client"
                });
        }


        [HttpDelete("api/v1/Montagem/Delete")]
        public IActionResult DeleteMontagem([FromBody] Montagem montagem)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || montagem.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err ECLI7003A - Security Error - Access denied"
                });

            

            if (montagem != null)
            {
                _montagemService.Delete(montagem);
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
