using Ardalis.Result;
using Contour.CleanArchitecture.Core.ProjectAggregate;

namespace Contour.CleanArchitecture.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
