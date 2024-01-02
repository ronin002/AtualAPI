using AtualAPI.Data;
using AtualAPI.Models;
using AtualAPI.Models.Workflow;
using System.Diagnostics;

namespace AtualAPI.Repository.Impl
{
    public class DecisionRepositoryImpl : IDecisionRepository
    {
        private readonly DataContext _context;
        public Decision GetDecisionById(Guid id)
        {
            var decision = _context.Decisions.FirstOrDefault(x => x.Id == id);
            if (decision != null)
                return decision;
            else
                return null;
        }

        public List<Decision> GetDecisionsByFlow(Guid idWorkFlow)
        {
            var decisions = _context.Decisions.Where(x => x.WorkFlowId == idWorkFlow).ToList();
            if (decisions != null)
                return decisions;
            else
                return null;
        }


        public bool Remove(Guid idDecision)
        {
            var decision = _context.Decisions.FirstOrDefault(x => x.Id == idDecision);
            if (decision != null)
            {
                _context.Decisions.Remove(decision);
                return true;
            }
            else
                return false;
        }

        public bool Save(Decision decision)
        {
            var decision1 = _context.Decisions.FirstOrDefault(x => x.Id == decision.Id);
            if (decision1 != null)
                return false;
            else
            {
                decision.CreationDate = DateTime.UtcNow;
                _context.Decisions.Add(decision);
            }

            return true;
        }

        public bool Update(Decision decision)
        {
            var groupRow1 = _context.Decisions.FirstOrDefault(x => x.Id == decision.Id);
            if (groupRow1 != null)
            {
                _context.Decisions.Update(decision);
                return true;
            }
            else
                return false;
        }
    }
}
