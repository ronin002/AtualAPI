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
    public class MontagemRepo : IMontagem
    {
        DataContext _context;
        public MontagemRepo(DataContext context)
        {
            _context = context;
        }
        public Montagem Add(Montagem montagem)
        {
            _context.Montagems.Add(montagem);
            _context.SaveChanges();
            return montagem;
        }

        public void Delete(Montagem montagem)
        {
            _context.Montagems.Remove(montagem);
            _context.SaveChanges();
        }

        public Montagem Get(Guid id)
        {
            return _context.Montagems.FirstOrDefault(x => x.Id == id);
        }

        public List<Montagem> GetAll(Guid companyId)
        {
            return _context.Montagems.Where(x => x.CompanyId == companyId).ToList();
        }

        public Montagem Update(Montagem montagem)
        {
            _context.Montagems.Update(montagem);
            _context.SaveChanges();
            return montagem;
        }
    }
}
