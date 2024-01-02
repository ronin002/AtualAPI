using Atual.Data.ImplRepositories;
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

    public class AddressesController : BaseController
    {

        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private const ETypeAccess ELocalTypeAccess = ETypeAccess.LevelContrato;

        public AddressesController(IUserService userService, IAddressService addressService) : base(userService, addressService)
        {
            //_logger = logger;
            _userService = userService;
            _addressService = addressService;
        }

        [HttpPost("api/v1/Address/create")]
        public IActionResult CreateAddress([FromBody] Address Address)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Add, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7001A - Security Error - Access denied"
                });

            var companyId = new UtilsController(_userService).GetCompany();
            Address.Id = Guid.NewGuid();
            Address.CompanyId = companyId;
            Address = _addressService.Add(Address);

            if (Address != null)
                return Ok(Address);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7001B - Error on try insert Address"
                });
        }


        [HttpGet("api/v1/Address/GetAddress")]
        public IActionResult GetAddress([FromBody] Guid id)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7002A - Security Error - Access denied"
                });

            var Address = _addressService.Get(id);
            var companyId = new UtilsController(_userService).GetCompany();

            if (Address != null && Address.CompanyId == companyId)
                return Ok(Address);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7002B - Error on try read Addresss"
                });

        }


        [HttpGet("api/v1/Address/GetAddresss")]
        public IActionResult GetAddress()
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.View, ELocalTypeAccess);

            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7003A - Security Error - Access denied"
                });

            var companyId = new UtilsController(_userService).GetCompany();

            var Addresss = _addressService.GetAll(companyId);

            if (Addresss != null)
                return Ok(Addresss);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7002B - Error on try read Addresss"
                });
        }


        [HttpPut("api/v1/Address/Update")]
        public IActionResult UpdateAddress([FromBody] Address Address)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Edit, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || Address.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7004A - Security Error - Access denied"
                });

            Address = _addressService.Update(Address);

            if (Address != null)
                return Ok(Address);
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7004B/Sec - Error on try read Addresss"
                });
        }


        [HttpDelete("api/v1/Address/Delete")]
        public IActionResult DeleteAddress([FromBody] Address Address)
        {
            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ELocalTypeAccess);

            var companyId = new UtilsController(_userService).GetCompany();

            if (!HasRole || Address.CompanyId != companyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7003A - Security Error - Access denied"
                });


            if (Address != null)
            {
                _addressService.Delete(Address);
                return Ok();
            }
            else
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err EADD7002B - Error on try read Addresss"
                });
        }
    }
}
