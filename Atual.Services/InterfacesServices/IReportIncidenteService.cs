using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IReportIncidenteService
    {
        
        List<ReportIncidente> GetAll(Guid CompanyId);
        ReportIncidente Get(Guid id);
        ReportIncidente Add(ReportIncidente reportIncidente);
        ReportIncidente Update(ReportIncidente reportIncidente);
        void Delete(ReportIncidente reportIncidente);
        

    }
}
