using CodeFirstExample.ValueObjects;

namespace CodeFirstExample.Entities
{

    public class WorkType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
    }

    public class WorkItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }
    }

    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public WorkItemValue Item { get; private set; }

        public Job() { }

        public Job(string title, WorkItemValue item)
        {
            Title = title;
            Item = item;
        }

        public void UpdateItem(WorkItemValue newItem)
        {
            Item = newItem;
        }
    }
}
