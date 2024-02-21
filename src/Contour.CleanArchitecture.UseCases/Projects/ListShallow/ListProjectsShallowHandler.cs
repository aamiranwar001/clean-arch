using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.UseCases.Projects.ListShallow;

public class ListProjectsShallowHandler(IListProjectsShallowQueryService query)
  : IQueryHandler<ListProjectsShallowQuery, Result<IEnumerable<ProjectDTO>>>
{
  public async Task<Result<IEnumerable<ProjectDTO>>> Handle(ListProjectsShallowQuery request, CancellationToken cancellationToken)
  {
    var result = await query.ListAsync();

    return Result.Success(result);
  }
}
