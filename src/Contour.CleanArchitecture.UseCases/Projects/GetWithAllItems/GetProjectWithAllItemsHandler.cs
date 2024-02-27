using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Domain.ProjectAggregate;
using Contour.CleanArchitecture.Domain.ProjectAggregate.Specifications;

namespace Contour.CleanArchitecture.UseCases.Projects.GetWithAllItems;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetProjectWithAllItemsHandler(IReadRepository<Project> repository) : IQueryHandler<GetProjectWithAllItemsQuery, Result<ProjectWithAllItemsDTO>>
{
  public async Task<Result<ProjectWithAllItemsDTO>> Handle(GetProjectWithAllItemsQuery request, CancellationToken cancellationToken)
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    var items = entity.Items
              .Select(i => new ToDoItemDTO(i.Id, i.Title, i.Description, i.IsDone, i.ContributorId))
              .ToList();

    return new ProjectWithAllItemsDTO(entity.Id, entity.Name, items, entity.Status.ToString());
  }
}
