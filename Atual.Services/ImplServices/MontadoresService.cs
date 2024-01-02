using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Atual.Data.ImplRepositories
{
    public class MontadoresService : IMontadoresService
    {
        IMontadores _montadores;
        public MontadoresService(IMontadores montadores)
        {
            _montadores = montadores;
        }
        public Montadores Add(Montadores Montadores)
        {
            return _montadores.Add(Montadores);
        }

        public void Delete(Montadores Montadores)
        {
            throw new NotImplementedException();
        }

        public Montadores Get(Guid id)
        {
            return _montadores.Get(id);
        }

        public List<Montadores> GetAll(Guid Id)
        {
            return _montadores.GetAll(Id);
        }

        public Montadores Update(Montadores Montadores)
        {
            _montadores.Update(Montadores);
            return Montadores;
        }
    }
}
