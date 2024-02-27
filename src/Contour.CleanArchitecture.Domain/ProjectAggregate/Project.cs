using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Domain.ProjectAggregate.Events;

namespace Contour.CleanArchitecture.Domain.ProjectAggregate;

public class Project : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  private readonly List<ToDoItem> _items = [];
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  public ProjectStatus Status => _items.TrueForAll(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  public PriorityStatus Priority { get; }

  public Project(string name, PriorityStatus priority)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    Priority = priority;
  }

  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    base.RegisterDomainEvent(newItemAddedEvent);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
