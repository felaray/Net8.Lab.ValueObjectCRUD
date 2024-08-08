using Microsoft.EntityFrameworkCore;

namespace DbFirstExample.ValueObject
{
    //DDD value object
    [Owned]
    public class WorkItemValue
    {
        public int WorkItemId { get; private set; }
        public string Description { get; private set; }
        public int WorkTypeId { get; private set; }
        public string WorkTypeName { get; private set; }

        public WorkItemValue(int workItemId, string description, int workTypeId, string workTypeName)
        {
            WorkItemId = workItemId;
            Description = description;
            WorkTypeId = workTypeId;
            WorkTypeName = workTypeName;
        }

        //equatable

    }
}
