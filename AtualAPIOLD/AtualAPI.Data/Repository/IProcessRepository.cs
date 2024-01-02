using AtualAPI.Models;

namespace AtualAPI.Repository
{
    public interface IProcessRepository
    {
        public Process GetProcessById(Guid id, Guid userId);
    }
}
