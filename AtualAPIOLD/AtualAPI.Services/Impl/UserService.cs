using AtualAPI.Dtos;
using AtualAPI.Models;
using AtualAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualAPI.Services.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public (bool, string) ValidUser(string userId, Guid companyId)
        {
            Guid IdUser = Guid.Empty;

            if (Guid.TryParse(userId, out IdUser))
            {
                return (false, "Err UAXV1001 invalid data user");
            }
            var user = _userRepo.GetAllUsers(companyId).Where(x=>x.UserId == IdUser).FirstOrDefault();
            if (user == null)
                return (false, "Err UAXV1001 user don't found");

            return (true, "");
        }
        
    }
}
