namespace DbFirstExample.ValueObject
{
    // 值物件
    public record WorkItemValue(int WorkItemId, string Description, int WorkTypeId, string WorkTypeName)
    {
        public int WorkItemId { get; private set; } = WorkItemId;
        public string Description { get; private set; } = Description;
        public int WorkTypeId { get; private set; } = WorkTypeId;
        public string WorkTypeName { get; private set; } = WorkTypeName;
    }
}
