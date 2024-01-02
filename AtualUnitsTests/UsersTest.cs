using Atual.Controllers;
using Atual.Data;
using Atual.Data.ImplRepositories;
using Atual.Data.InterfacesRepo;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Newtonsoft;
using Newtonsoft.Json;

namespace AtualUnitsTests
{
    public class UsersTest
    {
        private readonly ITestOutputHelper output;

        private DataContext _context { get; set; }
        private ILogger<UserController> _logger;
        private IUserService _userService;
        private IUserRepo _userRepo;
        private ICompanyRepo _companyRepo;

        public UsersTest(ITestOutputHelper outputHelper)
        {
            this.output = outputHelper;
            _context = new DataContext();
            _userRepo = new UserRepo(_context);
            _companyRepo = new CompanyRepo(_context);

            _userService = new UserService(_userRepo, _companyRepo);
        }

        [Fact]
        public async Task TestCreateUser_Return_User()
        {
          
            //Arrange
            var controller = new UserController(_logger, _userService);
            CreateUserDto createUser = new CreateUserDto();
            createUser.Email = "edso.marcio7@gmail.com";
            createUser.Name = "Edson";
            createUser.LastName = "Oliveira";
            createUser.Password = "Ab123456!";

            //Act
            IActionResult actionResult = await controller.CreateUser(createUser);
            var result = actionResult as OkObjectResult;

            UserModel model = (UserModel)result.Value;
            output.WriteLine("THIS IS OUTPUT" + model.Name) ;

            //Assert




        }
    }
}