using AtualAPI.Dtos;
using AtualAPI.Models;
using AtualAPI.Models.Workflow;
using AtualAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualAPI.Services.Interfaces
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkFlowRepository _wRepo;
        public WorkflowService(IWorkFlowRepository workFlowRepository)
        {
            _wRepo = workFlowRepository;
        }
        public (bool, string) ValidCreateWorkflow(string workflowName)
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(workflowName) || string.IsNullOrWhiteSpace(workflowName) || workflowName.Length < 3)
            {
                return (false,"Err WXE7002 invalid data - WorkFlow Name ");
            }

            return (true,"");

        }
        public (bool, string) ValidGiveLevelAccessToUser(ItemAccessLevelDto itemAccessLevel)
        {
 
            Guid workflowId = Guid.Empty;
            Guid userId = Guid.Empty;

            if (Guid.TryParse(itemAccessLevel.ItemId, out workflowId) ||
                Guid.TryParse(itemAccessLevel.UserId, out userId))
            {
                return (false, "Err WAXV1001 invalid data");
            }

            return (true, "");
        }
        public (WorkFlow,string) GetWorkFlowById(string WorkflowId)
        {

            Guid workflowId = Guid.Empty;

            if (Guid.TryParse(WorkflowId, out workflowId))
                return (null, "Err WGWID_1001 invalid data");
            
            var workflow = _wRepo.GetWorkFlowById(workflowId);

            return (workflow, "");

        }
        public bool GiveWorkflowAccessToUser(WorkFlowUsers workFlowUsers)
        {
            return true;
        }
    }
}
