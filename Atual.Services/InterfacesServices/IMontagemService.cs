using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IMontagemService
    {
        
        List<Montagem> GetAll(Guid CompanyId);
        Montagem Get(Guid id);
        Montagem Add(Montagem montagem);
        Montagem Update(Montagem montagem);
        void Delete(Montagem montagem);
        

    }
}
