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
    public class AmbienteRepo : IAmbiente
    {
        DataContext _context;
        public AmbienteRepo(DataContext context)
        {
            _context = context;
        }
        public Ambiente Add(Ambiente ambiente)
        {
            _context.Ambientes.Add(ambiente);
            _context.SaveChanges();
            return ambiente;
        }

        public void Delete(Ambiente ambiente)
        {
            _context.Ambientes.Remove(ambiente);
            _context.SaveChanges();
        }

        public Ambiente Get(Guid id)
        {
            return _context.Ambientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Ambiente> GetAll(Guid companyId)
        {
            return _context.Ambientes.Where(x => x.CompanyId == companyId).ToList();
        }

        public Ambiente Update(Ambiente ambiente)
        {
            _context.Ambientes.Update(ambiente);
            _context.SaveChanges();
            return ambiente;
        }
    }
}
