using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IReportIncidente
    {
        
        List<ReportIncidente> GetAll(Guid companyId);
        ReportIncidente Get(Guid id);
        ReportIncidente Add(ReportIncidente reportIncidente);
        ReportIncidente Update(ReportIncidente reportIncidente);
        void Delete(ReportIncidente reportIncidente);
        

    }
}
