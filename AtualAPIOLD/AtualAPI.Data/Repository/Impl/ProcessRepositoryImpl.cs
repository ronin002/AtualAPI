
using AtualAPI.Data;
using AtualAPI.Models;

namespace AtualAPI.Repository.Impl
{
    public class ProcessRepositoryImpl : IProcessRepository
    {
        private readonly DataContext _context;
        public ProcessRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public Process GetProcessById(Guid id, Guid userId)
        {

            var process = _context.Processes.FirstOrDefault(x => x.Id == id);
            if (process != null)
            {
                //if (process.OwnerId.Id == userId)
                return process;
            }
            else
            {
                return null;
            }

        }
    }
}
