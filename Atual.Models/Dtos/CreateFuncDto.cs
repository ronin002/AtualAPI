using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Models.Dtos
{
    public class CreateFuncDto
    {
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string? LastName { get; set; }
        public string Cargo { get; set; } = "";
    }
}
