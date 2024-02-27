using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.Domain.ProjectAggregate.Events;

public class NewItemAddedEvent(Project project,
    ToDoItem newItem) : DomainEventBase
{
  public ToDoItem NewItem { get; set; } = newItem;
  public Project Project { get; set; } = project;
}
