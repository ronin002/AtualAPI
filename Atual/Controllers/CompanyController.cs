using Atual.Data.InterfacesRepo;
using Atual.Models.Enum;
using Atual.Services.Utils;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Atual.Controllers
{

    [ApiController]

    public class CompanyController : BaseController
    {
        //private readonly ILogger<UserController> _logger;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public CompanyController(ICompanyService companyService, IUserService userService) : base(companyService)
        {
            //_logger = logger;
            _companyService = companyService;
            _userService = userService;
        }

        [HttpPost("api/v1/company/create")]
        public IActionResult CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
        {

            if (createCompanyDto == null)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CXE7001 invalid data"
             
                });

            var user = new UtilsController(_userService).GetUserLogged();//  base.GetUserLogged();// _userService.Get(guid);
            if (user.CompanyId != Guid.Empty)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CXE7002X - User already is company member"
                });

            var company = _companyService.Add(createCompanyDto, user.Id);

            user.CompanyId = company.Id;

            user = _userService.Update(user);

            return Ok(company);
        }



        [HttpGet("api/v1/company/GetCompany")]
        public IActionResult GetCompany([FromBody] string id)
        {
            var erros = new List<string>();

            try
            {
                UserModel user = new UtilsController(_userService).GetUserLogged();
                if (user.CompanyId.ToString() != id)
                    return BadRequest(new ErrorDto
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Err UXG7011X Server Error - Security prevention"
                    });

                var company = _userService.Get(Guid.Parse(id));
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011 Server Error"
                });
            }

        }


        [HttpGet("api/v1/company/GetCompanies")]
        public IActionResult GetCompanies()
        {
            UserModel user = new UtilsController(_userService).GetUserLogged();
            var companies = _companyService.GetAll(user);
            return Ok(companies);
        }

        
    }
}
