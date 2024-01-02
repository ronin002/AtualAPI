using System.Diagnostics;
using System.Text.RegularExpressions;
using AtualAPI.Models.Workflow;

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
        public IList<WorkFlow> WorkFlows { get; set; }
        public IList<Process> Processes { get; set; }
        public IList<Operation> Operations { get; set; }
        public IList<Contrato> Groups { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
