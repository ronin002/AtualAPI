using AtualAPI.Dtos;
using AtualAPI.Models;
using AtualAPI.Models.Dtos;

namespace AtualAPI.Repository
{
    public interface IUserRepository
    {
        public bool Save(UserModel user);
        public bool Update(UserModel user);
        public List<UserAndRole> GetAllUsers(Guid companyId);
        public UserModel GetById(Guid id);
        public UserModel GetByEmail(string email);
        public UserModel Login(string email, string password);
    }
}
