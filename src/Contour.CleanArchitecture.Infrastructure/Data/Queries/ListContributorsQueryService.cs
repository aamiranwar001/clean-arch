using Contour.CleanArchitecture.UseCases.Contributors;
using Contour.CleanArchitecture.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;

namespace Contour.CleanArchitecture.Infrastructure.Data.Queries;

public class ListContributorsQueryService(AppDbContext db) : IListContributorsQueryService
{
  // We can use EF, Dapper, SqlClient, etc. for queries - this is just an example

  public async Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider
    var result = await db.Contributors.FromSqlRaw("SELECT Id, Name FROM Contributors")
      .Select(c => new ContributorDTO(c.Id, c.Name))
      .ToListAsync();

    return result;
  }
}
