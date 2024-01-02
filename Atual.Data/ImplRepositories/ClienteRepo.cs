using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Atual.Data.ImplRepositories
{ 
    public class ClienteRepo : IClientRepo
    {
        DataContext _context;
        public ClienteRepo(DataContext context)
        {
            _context = context;
        }
        public Cliente Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public void Delete(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public Cliente Get(Guid id)
        {
            return _context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> GetAll(Guid companyId)
        {
            return _context.Clientes.Where(x => x.CompanyId == companyId).ToList();
        }

        public Cliente Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}
