
using AtualAPI.Dtos;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository
{
    public interface IArrowRepository
    {
        public List<ArrowDiagram> GetArrowsByFlow(Guid idWorkFlow);
        public ArrowDiagram GetArrowById(Guid id);
        public bool Save(ArrowDiagram arrowDiagram);
        public bool Update(ArrowDiagram arrowDiagram);
        public bool Remove (ArrowDiagram arrowDiagram);
    }
}
