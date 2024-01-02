using Atual.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Services.InterfacesServices
{
    public interface ILogsServices
    {
        HandledException HandleException(Exception ex, string errorTitle, string errorMessage, string origin);
        Log HandleLog(Log l);
    }
}
