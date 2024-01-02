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
    public class ReportIncidenteService : IReportIncidenteService
    {
        IReportIncidente _reportIncidente;
        public ReportIncidenteService(IReportIncidente reportIncidente)
        {
            _reportIncidente = reportIncidente;
        }
        public ReportIncidente Add(ReportIncidente reportIncidente)
        {
            return _reportIncidente.Add(reportIncidente);
        }

        public void Delete(ReportIncidente reportIncidente)
        {
            throw new NotImplementedException();
        }

        public ReportIncidente Get(Guid id)
        {
            return _reportIncidente.Get(id);
        }

        public List<ReportIncidente> GetAll(Guid Id)
        {
            return _reportIncidente.GetAll(Id);
        }

        public ReportIncidente Update(ReportIncidente reportIncidente)
        {
            _reportIncidente.Update(reportIncidente);
            return reportIncidente;
        }
    }
}
