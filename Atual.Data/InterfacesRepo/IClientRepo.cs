using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IClientRepo
    {
        
        List<Cliente> GetAll(Guid companyId);
        Cliente Get(Guid id);
        Cliente Add(Cliente cliente);
        Cliente Update(Cliente cliente);
        void Delete(Cliente cliente);
        

    }
}
