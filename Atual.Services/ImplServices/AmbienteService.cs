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
    public class AmbienteService : IAmbienteService
    {
        IAmbiente _ambiente;
        public AmbienteService(IAmbiente ambiente)
        {
            _ambiente = ambiente;
        }
        public Ambiente Add(Ambiente ambiente)
        {
            return _ambiente.Add(ambiente);
        }

        public void Delete(Ambiente ambiente)
        {
            throw new NotImplementedException();
        }

        public Ambiente Get(Guid id)
        {
            return _ambiente.Get(id);
        }

        public List<Ambiente> GetAll(Guid Id)
        {
            return _ambiente.GetAll(Id);
        }

        public Ambiente Update(Ambiente ambiente)
        {
            _ambiente.Update(ambiente);
            return ambiente;
        }
    }
}
