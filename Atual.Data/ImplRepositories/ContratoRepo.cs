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
    public class ContratoRepo : IContrato
    {
        DataContext _context;
        public ContratoRepo(DataContext context)
        {
            _context = context;
        }
        public Contrato Add(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            _context.SaveChanges();
            return contrato;
        }

        public void Delete(Contrato contrato)
        {
            _context.Contratos.Remove(contrato);
            _context.SaveChanges();
        }

        public Contrato Get(Guid id)
        {
            return _context.Contratos.FirstOrDefault(x => x.Id == id);
        }

        public List<Contrato> GetAll(Guid companyId)
        {
            return _context.Contratos.Where(x => x.CompanyId == companyId).ToList();
        }

        public Contrato Update(Contrato contrato)
        {
            _context.Contratos.Update(contrato);
            _context.SaveChanges();
            return contrato;
        }
    }
}
