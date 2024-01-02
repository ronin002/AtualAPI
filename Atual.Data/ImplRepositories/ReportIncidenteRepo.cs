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
    public class ReportIncidenteRepo : IReportIncidente
    {
        DataContext _context;
        public ReportIncidenteRepo(DataContext context)
        {
            _context = context;
        }
        public ReportIncidente Add(ReportIncidente reportIncidente)
        {
            _context.ReportIncidentes.Add(reportIncidente);
            _context.SaveChanges();
            return reportIncidente;
        }

        public void Delete(ReportIncidente reportIncidente)
        {
            _context.ReportIncidentes.Remove(reportIncidente);
            _context.SaveChanges();
        }

        public ReportIncidente Get(Guid id)
        {
            return _context.ReportIncidentes.FirstOrDefault(x => x.Id == id);
        }

        public List<ReportIncidente> GetAll(Guid companyId)
        {
            return _context.ReportIncidentes.ToList();
        }

        public ReportIncidente Update(ReportIncidente reportIncidente)
        {
            _context.ReportIncidentes.Update(reportIncidente);
            _context.SaveChanges();
            return reportIncidente;
        }
    }
}
