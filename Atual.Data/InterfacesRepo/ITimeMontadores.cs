using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface ITimeMontadores
    {
        
        List<TimeMontadores> GetAll(Guid CompanyId);
        TimeMontadores Get(Guid id);
        TimeMontadores Add(TimeMontadores timeMontadores);
        TimeMontadores Update(TimeMontadores timeMontadores);
        void Delete(TimeMontadores timeMontadores);
        

    }
}
