using AtualAPI.Dtos;
using AtualAPI.Models;
using AtualAPI.Models.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualAPI.Services.Interfaces
{
    public interface IWorkflowService
    {
        (bool, string) ValidCreateWorkflow(string workflowName);
        (bool, string) ValidGiveLevelAccessToUser(ItemAccessLevelDto itemAccessLevel);
        (WorkFlow, string) GetWorkFlowById(string WorkflowId);
        bool GiveWorkflowAccessToUser(WorkFlowUsers workFlowUsers);

    }
}
