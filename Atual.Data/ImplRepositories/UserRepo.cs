using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class UserRepo : IUserRepo
    {
        DataContext _context { get; set; }
        //private ILogsService LogsService { get; set; }
        public UserRepo(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<UserModel> Add(UserModel userModel)
        {
            try
            {
                await _context.Users.AddAsync(userModel);
                _context.SaveChanges();
                return userModel;
            }
            catch (Exception ex)
            {
                //throw LogsService.HandleException(ex, "User error", "There was an error adding the user",
                //    this.GetType().ToString());
            }
            return null;
        }

        public void Delete(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public UserModel Get(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> GetAll(Guid companyId)
        {
            return _context.Users.Where(x => x.CompanyId == companyId).ToList();
        }

        public UserModel Update(UserModel user)
        {            
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public UserModel Login(string email, string password)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x=> x.Email == email && x.Password == password);
                if (user == null) return null;
                return user;
            }
            catch (Exception ex)
            {
                //throw LogsService.HandleException(ex, "User error", "There was an error adding the user",
                //    this.GetType().ToString());
            }
            return null;
        }

        public UserModel GetByMail(string Email)
        {
            UserModel user = _context.Users.FirstOrDefault(x => x.Email == Email);
            return user;
        }
    }
}
