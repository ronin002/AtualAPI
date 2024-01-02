
using AtualAPI.Dtos;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository
{
    public interface IActivityRepository
    {
        public List<Activity> GetActivitiesByWorkFlow(Guid idWorkFlow, Guid idCompanys);
        public List<Activity> GetActivitiesCompany(Guid idCompany);
        public Activity GetActivitiesById(Guid id);
        public Activity AddActivityToWorkflow(Guid activityId, Guid workflowId, Guid idCompany);
        public bool Save(Activity activity);
        public bool SaveWithWorkflow(Activity activity, Guid WorkflowId);
        public bool Update(Activity activity);
        public bool Remove (Guid id);
    }
}
