using AtualAPI.Data;
using AtualAPI.Models;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Repository.Impl
{
    /*
    public class GroupRowsRepositoryImpl : IGroupRowsRepository
    {
        private readonly  DataContext _context;
        public GroupRows GetAGroupRowsById(Guid id)
        {
            var groupRows = _context.GroupRows.FirstOrDefault(x => x.Id == id);
            if (groupRows != null)
                return groupRows;
            else
                return null;
        }

        public GroupRows GetGroupRowsByActivity(Guid idActivity)
        {
            var groupRows = _context.GroupRows.FirstOrDefault(x => x.ActivityId == idActivity);
            if (groupRows != null)
                return groupRows;
            else
                return null;
        }

        public bool Remove(Guid idGroupRows)
        {
            var groupRows = _context.GroupRows.FirstOrDefault(x => x.Id == idGroupRows);
            if (groupRows != null)
            {
                _context.GroupRows.Remove(groupRows);
                return true;
            }
            else
                return false;
        }

        public bool Save(GroupRows groupRows)
        {
            var groupRow1 = _context.GroupRows.FirstOrDefault(x => x.Id == groupRows.Id);
            if (groupRow1 != null)
                return false;
            else
            {
                groupRows.CreationDate = DateTime.UtcNow;
                _context.GroupRows.Add(groupRows);
            }

            return true;
        }

        public bool Update(GroupRows groupRows)
        {
            var groupRow1 = _context.GroupRows.FirstOrDefault(x => x.Id == groupRows.Id);
            if (groupRow1 != null)
            {
                _context.GroupRows.Update(groupRows);
                return true;
            }
            else
                return false;
        }
    }
    */
}
