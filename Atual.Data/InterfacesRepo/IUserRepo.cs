using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IUserRepo
    {
        
        List<UserModel> GetAll(Guid companyId);
        UserModel Get(Guid id);
        UserModel GetByMail(string Email);
        Task<UserModel> Add(UserModel userModel);
        UserModel Update(UserModel userModel);
        void Delete(UserModel userModel);
        
        UserModel Login(string user, string password);

    }
}
