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

    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
                              IUserService userService) : base(userService)
        {
            _logger = logger;
            _userService = userService;
        }



        /*
        [HttpPost("api/v1/CreateOwner")]
        public IActionResult CreateUserOwner( [FromBody] CreateCompanyDto userCreateModel)
        {
            var erros = new List<string>();


            if (userCreateModel == null) 
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CYXE7001 invalid data"
                });

            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3)
            {
                erros.Add("Err COXE7002 invalid data");
            }

            var user = new UserModel();
            user = ReadToken();
            if (user.Id != user.CompanyId) 
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err CYXE7011 user already make part of a company"
                });

            if (!UtilsSecurity.ValidMail(user.Email))
            {
                erros.Add("Err CYXE7002 invalid data");
            }
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 3)
            {
                erros.Add("Err CYXE7003 invalid data");
            }

            Company company = new Company();
            company.Id = Guid.NewGuid();
            company.Name = userCreateModel.NameCompany;
            company.OwnerId = company.Id;
            var createCompany = _companyRepository.CreateCompany(company);

            if (!createCompany)
                erros.Add("Err CYXE7003 invalid data - Company Already Exists");

            if (erros.Count > 0)
            {
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

            
            Role role = new Role();
            
            role.Name = "OWNER";
            role.Id = Guid.NewGuid();
            role.CompanyId = user.Id;
            role.LevelProcess = ELevelAccess.OWner;
            role.LevelDashBoard = ELevelAccess.OWner;
            role.LevelAdmin = ELevelAccess.OWner;
            role.LevelOperations = ELevelAccess.OWner;
            role.LevelStations = ELevelAccess.OWner;
            role.LevelUsers = ELevelAccess.OWner;
            role.LevelRoles = ELevelAccess.OWner;
            _roleRepository.Save(role);

           

            var bOk = _userRepository.Save(user);


            if (bOk)
            {

                bOk = _roleRepository.AddRoleToUser(role, user);
                //bOk = _userRepository.Update(user);
                user.Password = "";
                return Ok(user); //RedirectToPage("dashboard.cshtml");
                //return StatusCode(StatusCodes.Status201Created, user.Email);

            }
            else
            {
                //erros.Add("User already exists");
                return BadRequest("User already exists");
            }
        }
        */


        [HttpPost("api/v1/user/")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userCreateModel)
        {
           
            if (userCreateModel == null)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UCXE7001 invalid data"
                });


            var user = new UserModel();
            user.Id = Guid.NewGuid();
            user.Email = userCreateModel.Email;
            user.Name = userCreateModel.Name;
            user.LastName = userCreateModel.LastName;
            user.CreationDate = DateTime.UtcNow;
            user.Password = userCreateModel.Password;

            var erros = _userService.ValidNewUser(user);

            if (erros.Count > 0)
            {
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

            user.Password = UtilsSecurity.HashPassword(user.Email, user.Password);
            user = await _userService.Add(user);

            if (user != null)
            {
                user.Password = "";
                return Ok(user); //RedirectToPage("dashboard.cshtml");

            }
            else
            {
                //erros.Add("User already exists");
                return BadRequest("Error on Insert. User already exists");
            }
        }




        [HttpGet("api/v1/user/GetUserById")]
        public IActionResult GetUser([FromBody] string id)
        {
            var erros = new List<string>();

            try
            {
                var user = new UserModel();
                user = _userService.Get(Guid.Parse(id));
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

        
        [HttpGet("api/v1/user/GetUsers")]
        public IActionResult GetUsers([FromBody] string CompanyId)
        {
            var erros = new List<string>();

            try
            {
                Guid guid = new Guid();
                if (Guid.TryParse(CompanyId, out guid))
                {
                    var user = new UserModel();
                    List<UserModel> users = _userService.GetAll(guid);
                    return Ok(users);
                }
                else 
                    return BadRequest(new ErrorDto
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Err UXG7011A - Company ID Invalid"
                    });
            }
            catch (Exception ex)
            {

                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011B Server Error"
                });
            }

        }


        [HttpGet("api/v1/user/GetUserByEmail")]
        public IActionResult GetUserByEmail([FromBody] string email)
        {
            var erros = new List<string>();

            try
            {

                var user = new UserModel();
                user = _userService.GetByMail(email);
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


        [HttpDelete("api/v1/user/DeleteUser")]
        public IActionResult DeleteUserByEmail([FromBody] Guid Id)
        {
            var erros = new List<string>();

            Guid guid = Guid.Empty;

            var userCaller = new UtilsController(_userService).GetUserLogged();
            var userDelete = _userService.Get(guid);

            if (userDelete == null)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011A2 - User don't exist"
                });

            if (userCaller.CompanyId != userDelete.CompanyId)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011A3 - Security Error - Admin warned"
                });

            var HasRole = new UtilsController(_userService).HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers);
            //if (HasRole(ELevelAccess.Remove, ETypeAccess.LevelUsers))
            if (!HasRole)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011A4 - Security Error - Access denied"
                });

            try
            {
                _userService.Delete(userCaller, userDelete);
                return Ok();
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

    }
}
