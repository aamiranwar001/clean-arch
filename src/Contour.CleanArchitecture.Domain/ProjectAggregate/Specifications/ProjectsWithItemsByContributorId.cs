using Ardalis.Specification;

namespace Contour.CleanArchitecture.Domain.ProjectAggregate.Specifications;

public class ProjectsWithItemsByContributorIdSpec : Specification<Project>
{
  public ProjectsWithItemsByContributorIdSpec(int contributorId)
  {
    Query
        .Where(project => project.Items.Any(item => item.ContributorId == contributorId))
        .Include(project => project.Items);
  }
}
