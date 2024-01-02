using AtualAPI.Data;
using AtualAPI.Dtos;
using AtualAPI.Models;
using AtualAPI.Models.Workflow;
using System.ComponentModel.Design;
using System.Data;

namespace AtualAPI.Repository.Impl
{
    public class ActivityRepositoryImpl : IActivityRepository
    {
        private readonly DataContext _context;

        public ActivityRepositoryImpl(DataContext context)
        {
            _context = context;
        }
        public List<Activity> GetActivitiesByWorkFlow(Guid idWorkFlow, Guid idCompany)
        {

            var activitiesWorkflow = _context.activityWorkflows.Where(aw => aw.WorkflowId == idWorkFlow).ToList();

            var activitiesAllCompany = _context.Activities.Where(x => x.CompanyId == idCompany).ToList();
            List<Activity> activities = new List<Activity>();
            activities = (from ac in activitiesAllCompany
                                join q in activitiesWorkflow on ac.Id equals q.ActivityId
                          select ac )
                          .Distinct().ToList();
           
            if (activities != null)
                return activities;
            else
                return null;
        }

        public Activity AddActivityToWorkflow(Guid activityId, Guid workflowId, Guid idCompany)
        {

            var activity = _context.Activities.Where(x => x.Id == activityId
                                                && x.CompanyId == idCompany).FirstOrDefault();

            var workflow = _context.Workflows.Where(x => x.Id == workflowId
                                                && x.CompanyId == idCompany).FirstOrDefault();

            if (workflow == null || activity == null)
                return null;

            var qtdActivitiesWorkflow = _context.activityWorkflows
                .Where(aw => aw.WorkflowId == workflowId && aw.ActivityId == activityId).Count();

            if (qtdActivitiesWorkflow > 0)
                return activity;

            ActivityWorkflow aw = new ActivityWorkflow();
            aw.Id = Guid.NewGuid();
            aw.ActivityId = activityId;
            aw.WorkflowId = workflowId;
            aw.Enabled = true;
            _context.activityWorkflows.Add(aw);
            _context.SaveChanges();

            return activity;

        }

        public Activity GetActivitiesById(Guid id)
        {
            var activities = _context.Activities.FirstOrDefault(x => x.Id == id);
            if (activities != null)
                return activities;
            else
                return null;
        }

        public List<Activity> GetActivitiesCompany(Guid idCompany)
        {
            var activities = _context.Activities.Where(x=>x.CompanyId == idCompany).ToList();
            if (activities != null)
                return activities;
            else
                return null;
        }

        public bool Remove(Guid id)
        {
            var activity = _context.Activities.FirstOrDefault(x => x.Id == id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                return true;
            }
            else
                return false;
        }

        public bool Save(Activity activity)
        {
            var activity1 = _context.Activities.FirstOrDefault(x => x.Id == activity.Id);
            if (activity1 != null)
                return false;
            else
            {
                activity.CreationDate = DateTime.UtcNow;
                _context.Activities.Add(activity);
                _context.SaveChanges();
            }


                return true;
        }
        
        public bool SaveWithWorkflow(Activity activity, Guid WorkflowId)
        {
            var activity1 = _context.Activities.FirstOrDefault(x => x.Id == activity.Id);
            var Workflow1 = _context.Workflows.FirstOrDefault(x => x.Id == WorkflowId);

            if (activity1 != null || Workflow1 == null)
                return false;
            else
            {
                activity.CreationDate = DateTime.UtcNow;

                

                _context.Activities.Add(activity);
                _context.SaveChanges();

                ActivityWorkflow activityWorkflow = new ActivityWorkflow();
                activityWorkflow.ActivityId = activity.Id;
                activityWorkflow.WorkflowId = WorkflowId;
                activityWorkflow.Enabled = true;

                _context.activityWorkflows.Add(activityWorkflow);
                _context.SaveChanges();

            }


            return true;
        }

        public bool Update(Activity activity)
        {
            var activity1 = _context.Activities.FirstOrDefault(x => x.Id == activity.Id);
            if (activity1 != null)
            {
                _context.Activities.Update(activity);
                return true;
            }
            else
                return false;
        }
    }
}
