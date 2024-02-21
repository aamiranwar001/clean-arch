using Contour.CleanArchitecture.UseCases.Projects;
using Contour.CleanArchitecture.UseCases.Projects.ListShallow;
using Microsoft.EntityFrameworkCore;

namespace Contour.CleanArchitecture.Infrastructure.Data.Queries;

public class ListProjectsShallowQueryService(AppDbContext _db) : IListProjectsShallowQueryService
{
  public async Task<IEnumerable<ProjectDTO>> ListAsync()
  {
    var result = await _db.Projects.FromSqlRaw("SELECT Id, Name FROM Projects")
      .Select(x => new ProjectDTO(x.Id, x.Name, x.Status.ToString()))
      .ToListAsync();

    return result;
  }
}
