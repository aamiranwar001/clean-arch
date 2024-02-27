using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.Domain.ProjectAggregate.Events;

public class ContributorAddedToItemEvent(ToDoItem item, int contributorId) : DomainEventBase
{
  public int ContributorId { get; set; } = contributorId;
  public ToDoItem Item { get; set; } = item;
}
