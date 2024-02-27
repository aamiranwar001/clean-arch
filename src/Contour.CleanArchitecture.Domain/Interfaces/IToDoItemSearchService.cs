using Ardalis.Result;
using Contour.CleanArchitecture.Domain.ProjectAggregate;

namespace Contour.CleanArchitecture.Domain.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
