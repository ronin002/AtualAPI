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
    public class MontadoresRepo : IMontadores
    {
        DataContext _context;
        public MontadoresRepo(DataContext context)
        {
            _context = context;
        }
        public Montadores Add(Montadores Montadores)
        {
            _context.Montadores.Add(Montadores);
            _context.SaveChanges();
            return Montadores;
        }

        public void Delete(Montadores Montadores)
        {
            _context.Montadores.Remove(Montadores);
            _context.SaveChanges();
        }

        public Montadores Get(Guid id)
        {
            return _context.Montadores.FirstOrDefault(x => x.Id == id);
        }

        public List<Montadores> GetAll(Guid companyId)
        {
            return _context.Montadores.Where(x => x.CompanyId == companyId).ToList();
        }

        public Montadores Update(Montadores Montadores)
        {
            _context.Montadores.Update(Montadores);
            _context.SaveChanges();
            return Montadores;
        }
    }
}
