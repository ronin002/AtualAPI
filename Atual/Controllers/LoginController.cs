using Atual.Data.InterfacesRepo;
using Atual.Services.Utils;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atual.Controllers
{
    public class LoginController : BaseController
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IRoleUserService _roleUserService;
        public LoginController(ILogger<UserController> logger,
                              IUserService userService,
                              IRoleUserService roleUserService) : base(userService)
        {
            _logger = logger;
            _userService = userService;
            _roleUserService = roleUserService;
        }


        [HttpPost("api/v1/login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] LoginUserDto userLogin)
        {
            if (userLogin == null)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UCXE7001 invalid data"
                });

            var erros = _userService.ValidLogin(userLogin);
            if (erros.Count > 0)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });

            var user = new UserModel();

            user = _userService.Login(userLogin);

            if (user != null)
            {
                var roles = new List<Role>();
                user.Password = "";

                if (user.CompanyId != Guid.Empty)                  
                    roles = _roleUserService.GetRoleUser(user); // _roleRepository.GetRoleUser(user.Id);

                var token = TokenService.GenerateToken(user, roles);
                var retorno = new
                {
                    Token = token,
                    user = user
                };
                return Ok(retorno);

                //return View("~/dashboard/dashboard");
                //return RedirectToAction("Dashboard", "Dashboard", new { Retorno = retorno });
                //return View("~/views/dashboard/dashboard.cshtml", new { Retorno = retorno });


                //return RedirectToPage("/dashboard.cshtml", new { Retorno = retorno });
                //return RedirectToPage($"~/dashboard.cshtml", new { Retorno = retorno });
                //return Ok(retorno);
            }
            else
            {
                erros.Add("Login invalid data ");

                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

        }
    }
}
