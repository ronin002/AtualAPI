using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IAmbiente
    {
        
        List<Ambiente> GetAll(Guid companyId);
        Ambiente Get(Guid id);
        Ambiente Add(Ambiente ambiente);
        Ambiente Update(Ambiente ambiente);
        void Delete(Ambiente ambiente);
        

    }
}
