using CodeFirstExample.Data;
using CodeFirstExample.Entities;
using CodeFirstExample.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstExample.Services
{
    public interface IJobServices
    {
        Task PostJob(string title, int? workItemId);
        Task PutJob(int id, int? workItemId);
        Task<List<Job>> GetJobs();
        Task<Job> GetLast();
    }

    public class JobServices : IJobServices
    {
        private readonly CodeFirstExampleContext _context;

        public JobServices(CodeFirstExampleContext context)
        {
            _context = context;
        }


        public async Task<List<Job>> GetJobs()
        {
            var result = await _context.Jobs.ToListAsync();
            return result;
        }

        public Task<Job> GetLast()
        {
            return _context.Jobs.OrderByDescending(c => c.Id).FirstOrDefaultAsync();
        }

        public async Task PostJob(string title, int? workItemId)
        {
            WorkItem workItem = null;
            if (workItemId.HasValue)
                workItem = await GetById(workItemId.Value);
            else
                workItem = await GetAny();

            if (workItem == null)
            {
                throw new Exception($"WorkItem {workItemId} not found");
            }

            var job = new Job(title, new WorkItemValue(workItem.Id, workItem.Description, workItem.WorkTypeId, workItem.WorkType.Name));
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task PutJob(int id, int? workItemId)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                throw new Exception($"Job {id} not found");
            }

            WorkItem workItem = null;
            if (workItemId.HasValue)
                workItem = await GetById(workItemId.Value);
            else
                workItem = await GetAny();

            if (workItem == null)
            {
                throw new Exception($"WorkItem {workItemId} not found");
            }

            job.UpdateItem(new WorkItemValue(workItem.Id, workItem.Description, workItem.WorkTypeId, workItem.WorkType.Name));

            _context.SaveChanges();
        }

        private async Task<WorkItem> GetAny()
        {
            var count = await _context.WorkItems.CountAsync();
            var index = new Random().Next(count);

            return await _context.WorkItems.Skip(index).Include(c => c.WorkType).FirstAsync();
        }

        private async Task<WorkItem> GetById(int id)
        {
            return await _context.WorkItems.Include(c => c.WorkType).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
