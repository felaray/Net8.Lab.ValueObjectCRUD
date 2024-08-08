using DbFirstExample.ValueObject;
namespace DbFirstExample.Models;

public partial class Job
{
    // valueObject
    public WorkItemValue Item { get; set; }
}
