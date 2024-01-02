using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class TimeMontadoresService : ITimeMontadoresService
    {
        ITimeMontadores _timeMontadores;
        public TimeMontadoresService(ITimeMontadores timeMontadores)
        {
            _timeMontadores = timeMontadores;
        }
        public TimeMontadores Add(TimeMontadores timeMontadores)
        {
            throw new NotImplementedException();
        }

        public void Delete(TimeMontadores timeMontadores)
        {
            throw new NotImplementedException();
        }

        public TimeMontadores Get(Guid id)
        {
            return _timeMontadores.Get(id);
        }

        public List<TimeMontadores> GetAll(Guid companyId)
        {
            return _timeMontadores.GetAll(companyId);
        }

        public TimeMontadores Update(TimeMontadores timeMontadores)
        {
            throw new NotImplementedException();
        }
    }
}
