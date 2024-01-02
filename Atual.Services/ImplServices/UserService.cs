using Atual.Data.InterfacesRepo;
using Atual.Services.Utils;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Atual.Data;
using AtualAPI.Dtos;
using System.Net;
using System.ComponentModel.Design;


namespace Atual.Data.ImplRepositories
{
    public class UserService : IUserService
    {
        IUserRepo _userRepo;
        ICompanyRepo _companyRepo;
        public UserService(IUserRepo userRepo, ICompanyRepo companyRepo)
        {
            _userRepo = userRepo;
            _companyRepo = companyRepo;
        }
        public async Task<UserModel> Add(UserModel user)
        {
            return await _userRepo.Add(user);
        }

        public void Delete( UserModel userCaller, UserModel userDelete)
        {            
            //if (!TokenService.HasRole(identity, Models.Enum.ELevelAccess.Remove, Models.Enum.ETypeAccess.LevelUsers, (Guid)userCaller.CompanyId))
            _userRepo.Delete(userDelete);
        }

        public UserModel Get(Guid id)
        {
            return _userRepo.Get(id);
        }

        public List<UserModel> GetAll(Guid companyId )
        {
            return _userRepo.GetAll(companyId);
        }

        public Company GetCompany(Guid companyId)
        {
            return _companyRepo.Get(companyId);
        }

        public UserModel Update(UserModel userModel)
        {
            return _userRepo.Update(userModel);
        }

        public UserModel Login(LoginUserDto userLogin)
        {
            return _userRepo.Login(userLogin.Email, UtilsSecurity.HashPassword(userLogin.Email, userLogin.Password));
        }

        public List<string> ValidNewUser(UserModel user)
        {
            List<string> erros = new List<string>();

            if (!UtilsSecurity.ValidMail(user.Email))
            {
                erros.Add("Err UCXE7002 invalid data - Invalid Email");
            }
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrWhiteSpace(user.Name) || user.Name.Length < 3)
            {
                erros.Add("Err UCXE7003a invalid data - name too short");
            }
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 3)
            {
                erros.Add("Err UCXE7003b invalid data - password too short");
            }
            UserModel user1 = _userRepo.GetByMail(user.Email);
            if ( user1 != null )
            {
                erros.Add("Err UCXE7003c User already exists");
            }

            return erros;
        }

        public List<string> ValidLogin(LoginUserDto userLogin)
        {
            List<string> erros = new List<string>();
            if (!UtilsSecurity.ValidMail(userLogin.Email))
            {
                erros.Add("Login invalid data ");
            }
            if (string.IsNullOrEmpty(userLogin.Password) || string.IsNullOrWhiteSpace(userLogin.Password) || userLogin.Password.Length < 3)
            {
                erros.Add("Login invalid data ");
            }

            return erros;
        }

        public UserModel GetByMail(string Email)
        {
            if (!UtilsSecurity.ValidMail(Email))
                return null;
            
            UserModel user1 = _userRepo.GetByMail(Email);
            return user1;
        }
    }
}
