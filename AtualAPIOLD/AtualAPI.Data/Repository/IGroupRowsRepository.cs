
using AtualAPI.Dtos;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository
{
    public interface IGroupRowsRepository
    {
        public GroupRows GetGroupRowsByActivity(Guid idActivity);
        public GroupRows GetAGroupRowsById(Guid id);
        public bool Save(GroupRows groupRows);
        public bool Update(GroupRows groupRows);
        public bool Remove (Guid idGroupRows);
    }
}
