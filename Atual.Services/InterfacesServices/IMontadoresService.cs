using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IMontadoresService
    {
        
        List<Montadores> GetAll(Guid CompanyId);
        Montadores Get(Guid id);
        Montadores Add(Montadores Montadores);
        Montadores Update(Montadores Montadores);
        void Delete(Montadores Montadores);
        

    }
}
