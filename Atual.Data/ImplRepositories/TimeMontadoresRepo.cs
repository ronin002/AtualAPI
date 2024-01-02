using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class TimeMontadoresRepo : ITimeMontadores
    {
        DataContext _context;
        public TimeMontadoresRepo(DataContext context)
        {
            _context = context;
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
            throw new NotImplementedException();
        }

        public List<TimeMontadores> GetAll(Guid companyId)
        {
            return _context.TimesMontadores.Where(x => x.CompanyId == companyId).ToList();
        }

        public TimeMontadores Update(TimeMontadores timeMontadores)
        {
            _context.TimesMontadores.Update(timeMontadores);
            _context.SaveChanges();
            return timeMontadores;
        }
    }
}
