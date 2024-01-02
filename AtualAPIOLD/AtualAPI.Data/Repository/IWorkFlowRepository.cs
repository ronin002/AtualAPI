
using AtualAPI.Dtos;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository
{
    public interface IWorkFlowRepository
    {
        public List<WorkFlow> GetWorkFlowsCompany(Guid idCompany);
        public WorkFlow GetWorkFlowById(Guid id);
        public WorkFlow Save(string workFlow, Guid idCompany);
        public bool GiveLevelAccessToUser(WorkFlowUsers itemAccessLevel);
        public bool Update(WorkFlow workFlow);
        public bool Remove (Guid idWorkFlow);
    }
}
