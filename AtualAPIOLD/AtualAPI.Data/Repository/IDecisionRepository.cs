
using AtualAPI.Dtos;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository
{
    public interface IDecisionRepository
    {
        public List<Decision> GetDecisionsByFlow(Guid idWorkFlow);
        public Decision GetDecisionById(Guid id);
        public bool Save(Decision decision);
        public bool Update(Decision decision);
        public bool Remove (Guid idDecision);
    }
}
