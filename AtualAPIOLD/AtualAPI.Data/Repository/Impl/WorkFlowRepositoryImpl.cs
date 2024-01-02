using AtualAPI.Data;
using AtualAPI.Dtos;
using AtualAPI.Models;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository.Impl
{
    public class WorkFlowRepositoryImpl : IWorkFlowRepository
    {
        private readonly DataContext _context;

        public WorkFlowRepositoryImpl(DataContext context)
        {
            _context = context;
        }
        public WorkFlow GetWorkFlowById(Guid id)
        {
            var workflow = _context.Workflows.FirstOrDefault(x => x.Id == id);
            if (workflow != null)
                return workflow;
            else
                return null;
        }

        public List<WorkFlow> GetWorkFlowsCompany(Guid idCompany)
        {
            var workflows = _context.Workflows.ToList();
            if (workflows != null)
                return workflows;
            else
                return null;
        }

        public bool Remove(Guid idWorkFlow)
        {
            var workFlow = _context.Workflows.FirstOrDefault(x => x.Id == idWorkFlow);
            if (workFlow != null)
            {
                _context.Workflows.Remove(workFlow);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public  WorkFlow Save(string workFlowName, Guid idCompany)
        {
            var workFlow1 = _context.Workflows.Count(x => x.Name == workFlowName);
            if (workFlow1 > 0)
                return null;
            else
            {

                WorkFlow workFlow = new WorkFlow();
                workFlow.Id = Guid.NewGuid();
                workFlow.CompanyId = idCompany;
                workFlow.Name = workFlowName;
                workFlow.CreationDate = DateTime.UtcNow;

                _context.Workflows.Add(workFlow);
                _context.SaveChanges(); 

                return workFlow;
            }

        }

        public bool Update(WorkFlow workFlow)
        {
            var workFlow1 = _context.Workflows.FirstOrDefault(x => x.Id == workFlow.Id);
            if (workFlow1 != null)
            {
                _context.Workflows.Update(workFlow);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool GiveLevelAccessToUser(WorkFlowUsers itemAccessLevel)
        {
            //Ja deve ter verificado se tem acesso > para dar acesso <
            var userAlredHaveAccess = _context.workflows_users
                            .Where(x => x.UserId == itemAccessLevel.UserId && 
                                   x.WorkflowId == itemAccessLevel.WorkflowId &&
                                   x.CompanyId == itemAccessLevel.CompanyId).FirstOrDefault();



            if (userAlredHaveAccess != null) 
            {
                userAlredHaveAccess.LevelAccess =  itemAccessLevel.LevelAccess;
                _context.workflows_users.Update(userAlredHaveAccess);
                _context.SaveChanges();
                return true;
            }

            WorkFlowUsers workFlowUsers = new WorkFlowUsers();
            workFlowUsers.Id = Guid.NewGuid();
            workFlowUsers.UserId = itemAccessLevel.UserId;
            workFlowUsers.CompanyId = itemAccessLevel.CompanyId;
            workFlowUsers.WorkflowId = itemAccessLevel.WorkflowId;
            workFlowUsers.LevelAccess = itemAccessLevel.LevelAccess;

            _context.workflows_users.Add(workFlowUsers);
            _context.SaveChanges();
            return true;

        }


    }
}
