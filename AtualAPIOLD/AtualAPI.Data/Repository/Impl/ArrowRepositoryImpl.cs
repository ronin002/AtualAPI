using AtualAPI.Data;
using AtualAPI.Models;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository.Impl
{
    public class ArrowRepositoryImpl : IArrowRepository
    {
        private readonly DataContext _context;
        public List<ArrowDiagram> GetArrowsByFlow(Guid idWorkFlow)
        {
            var arrows = _context.ArrowDiagrams.Where(x => x.WorkFlowId == idWorkFlow).ToList();
            if (arrows != null)
                return arrows;
            else
                return null;
        }

        public ArrowDiagram GetArrowById(Guid id)
        {
            var arrow = _context.ArrowDiagrams.FirstOrDefault(x => x.Id == id);
            if (arrow != null)
                return arrow;
            else
                return null;
        }


        public bool Remove(ArrowDiagram arrowDiagram)
        {
            var arrow = _context.ArrowDiagrams.FirstOrDefault(x => x.Id == arrowDiagram.Id);
            if (arrow != null)
            {
                _context.ArrowDiagrams.Remove(arrowDiagram);
                return true;
            }
            else
                return false;
        }

        public bool Save(ArrowDiagram arrowDiagram)
        {
            var arrow = _context.ArrowDiagrams.FirstOrDefault(x => x.Id == arrowDiagram.Id);
            if (arrow != null)
                return false;
            else
            {
                arrowDiagram.CreationDate = DateTime.UtcNow;
                _context.ArrowDiagrams.Add(arrowDiagram);
            }
               
            return true;
        }

        public bool Update(ArrowDiagram arrowDiagram)
        {
            var arrow = _context.ArrowDiagrams.FirstOrDefault(x => x.Id == arrowDiagram.Id);
            if (arrow != null)
            {
                _context.ArrowDiagrams.Update(arrowDiagram);
                return true;
            }
            else
                return false;
        }
    }
}
