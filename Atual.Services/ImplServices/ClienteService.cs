using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Atual.Data.ImplRepositories
{
    public class ClienteService : IClientService
    {
        IClientRepo _clientRepo;
        public ClienteService(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }
        public Cliente Add(Cliente cliente)
        {
            return _clientRepo.Add(cliente);
        }

        public void Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(Guid id)
        {
            return _clientRepo.Get(id);
        }

        public List<Cliente> GetAll(Guid Id)
        {
            return _clientRepo.GetAll(Id);
        }

        public Cliente Update(Cliente cliente)
        {
            _clientRepo.Update(cliente);
            return cliente;
        }
    }
}
