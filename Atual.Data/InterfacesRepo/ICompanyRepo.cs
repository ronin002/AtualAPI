using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface ICompanyRepo
    {
        
        List<Company> GetAll();
        Company Get(Guid id);
        Company Add(Company company);
        Company Update(Company company);
        void Delete(Company company);
        

    }
}
