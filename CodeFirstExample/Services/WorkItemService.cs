using Microsoft.EntityFrameworkCore;
using CodeFirstExample.Data;
using CodeFirstExample.Entities;

namespace CodeFirstExample.Services
{
    public interface IWorkItemService
    {
        Task<List<WorkItem>> GetWorkItems();
        Task PostWorkItem(string description, int workTypeId);
        Task PutWorkItem(int id, string description, int workTypeId);
    }

    public class WorkItemService : IWorkItemService
    {
        private readonly CodeFirstExampleContext _context;

        public WorkItemService(CodeFirstExampleContext context)
        {
            _context = context;
        }

        public async Task<List<WorkItem>> GetWorkItems()
        {
            var result = await _context.WorkItems.ToListAsync();
            return result;
        }

        public async Task PostWorkItem(string description, int workTypeId)
        {
            var workType = await _context.WorkTypes.FindAsync(workTypeId);
            if (workType == null)
            {
                throw new Exception($"WorkType {workTypeId} not found");
            }

            var workItem = new WorkItem
            {
                Description = description,
                WorkTypeId = workTypeId,
                WorkType = workType
            };
            _context.WorkItems.Add(workItem);
            await _context.SaveChangesAsync();
        }

        public async Task PutWorkItem(int id, string description, int workTypeId)
        {
            var workItem = await _context.WorkItems.FindAsync(id);
            if (workItem == null)
            {
                throw new Exception($"WorkItem {id} not found");
            }

            var workType = await _context.WorkTypes.FindAsync(workTypeId);
            if (workType == null)
            {
                throw new Exception($"WorkType {workTypeId} not found");
            }

            workItem.Description = description;
            workItem.WorkTypeId = workTypeId;
            workItem.WorkType = workType;
            await _context.SaveChangesAsync();
        }
    }
}
