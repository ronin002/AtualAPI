using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AtualAPI.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string BussinesPlan { get; set; }
        public string BussinesPlanStatus { get; set; }
        public IList<UserModel> Users { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<Cliente> Clientes { get; set; }
        public IList<Contrato> Contratos { get; set; }
        public IList<Funcionario> Funcionarios { get; set; }
        public IList<Montadores> Montadores { get; set; }
        public IList<TimeMontadores> TimesMontagem { get; set; }
        public IList<Montagem> Montagems { get; set; }
        public IList<Ambiente> Ambientes { get; set; }
        public IList<ReportIncidente> ReportIncidentes { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Company()
        {
            Users = new List<UserModel>();
            Roles = new List<Role>();
            Clientes = new List<Cliente>();
            Contratos = new List<Contrato>();
            Funcionarios = new List<Funcionario>();
            Montagems = new List<Montagem>();
            Ambientes = new List<Ambiente>();
            ReportIncidentes = new List<ReportIncidente>();
        }

    }
}
