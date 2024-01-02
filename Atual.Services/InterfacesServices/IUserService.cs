using AtualAPI.Dtos;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IUserService
    {
        
        List<UserModel> GetAll(Guid companyId);
        UserModel Get(Guid id);
        UserModel GetByMail(string Email);
        Company GetCompany(Guid companyId);
        Task<UserModel> Add(UserModel userModel);
        UserModel Update(UserModel userModel);
        void Delete(UserModel userCaller, UserModel userDelete);

        UserModel Login(LoginUserDto userLogin);
        List<string> ValidNewUser(UserModel userModel);
        List<string> ValidLogin(LoginUserDto userLogin);
        

    }
}
