using Contour.CleanArchitecture.UseCases.Projects;
using Contour.CleanArchitecture.UseCases.Projects.ListIncompleteItems;

namespace Contour.CleanArchitecture.Infrastructure.Data.Queries;

public class FakeListIncompleteItemsQueryService : IListIncompleteItemsQueryService
{
  public async Task<IEnumerable<ToDoItemDTO>> ListAsync(int projectId)
  {
    var testItem = new ToDoItemDTO(Id: 1000, Title: "test", Description: "test description", IsComplete: false, null);
    return await Task.FromResult(new List<ToDoItemDTO>() { testItem });
  }
}
