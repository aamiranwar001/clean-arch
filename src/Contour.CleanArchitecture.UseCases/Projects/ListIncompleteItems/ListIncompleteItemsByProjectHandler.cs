using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.UseCases.Projects.ListIncompleteItems;

public class ListIncompleteItemsByProjectHandler(IListIncompleteItemsQueryService query)
  : IQueryHandler<ListIncompleteItemsByProjectQuery, Result<IEnumerable<ToDoItemDTO>>>
{
  public async Task<Result<IEnumerable<ToDoItemDTO>>> Handle(ListIncompleteItemsByProjectQuery request, CancellationToken cancellationToken)
  {
    var result = await query.ListAsync(request.ProjectId);

    return Result.Success(result);
  }
}
