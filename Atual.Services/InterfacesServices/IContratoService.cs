using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IContratoService
    {
        
        List<Contrato> GetAll(Guid CompanyId);
        Contrato Get(Guid id);
        Contrato Add(Contrato contrato);
        Contrato Update(Contrato contrato);
        void Delete(Contrato contrato);
        

    }
}
