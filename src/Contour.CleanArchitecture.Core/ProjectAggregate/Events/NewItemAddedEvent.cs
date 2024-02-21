using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.Core.ProjectAggregate.Events;

public class NewItemAddedEvent(Project project,
    ToDoItem newItem) : DomainEventBase
{
  public ToDoItem NewItem { get; set; } = newItem;
  public Project Project { get; set; } = project;
}
