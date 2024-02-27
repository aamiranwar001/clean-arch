using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.Domain.ProjectAggregate.Events;

public class ToDoItemCompletedEvent(ToDoItem completedItem) : DomainEventBase
{
  public ToDoItem CompletedItem { get; set; } = completedItem;
}
