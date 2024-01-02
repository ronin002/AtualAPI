using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IContrato
    {
        
        List<Contrato> GetAll(Guid companyId);
        Contrato Get(Guid id);
        Contrato Add(Contrato contrato);
        Contrato Update(Contrato contrato);
        void Delete(Contrato contrato);
        

    }
}
