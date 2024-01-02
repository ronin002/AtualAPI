using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Models.Models
{
    public class HandledException : Exception
    {
        public string ErrorTitle { get; set; }
        public string ErrorMessage { get; set; }

        public HandledException(Exception ex, string errorTitle, string errorMessage) : base(null, ex)
        {
            ErrorTitle = errorTitle;
            ErrorMessage = errorMessage;
        }
    }
}
