using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IAddressService
    {
        
        List<Address> GetAll(Guid CompanyId);
        Address Get(Guid id);
        Address Add(Address address);
        Address Update(Address address);
        void Delete(Address address);
        

    }
}
