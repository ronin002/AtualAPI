using AtualAPI.Dtos;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface ICompanyService
    {
        
        List<Company> GetAll(UserModel user);
        Company Get(Guid id);
        Company Add(CreateCompanyDto company, Guid Owner);
        Company Update(Company company);
        void Delete(Company company);
        

    }
}
