using AtualAPI.Dtos;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualAPI.Services.Interfaces
{
    public interface IUserService
    {
        (bool, string) ValidUser(string userId, Guid companyId);
        
    }
}
