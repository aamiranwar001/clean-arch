using Ardalis.Specification;

namespace Contour.CleanArchitecture.Domain.ProjectAggregate.Specifications;

public class ProjectByIdWithItemsSpec : Specification<Project>
{
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
        .Where(project => project.Id == projectId)
        .Include(project => project.Items);
  }
}
