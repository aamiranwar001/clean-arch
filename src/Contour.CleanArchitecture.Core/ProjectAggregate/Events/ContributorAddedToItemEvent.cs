using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.Core.ProjectAggregate.Events;

public class ContributorAddedToItemEvent(ToDoItem item, int contributorId) : DomainEventBase
{
  public int ContributorId { get; set; } = contributorId;
  public ToDoItem Item { get; set; } = item;
}
