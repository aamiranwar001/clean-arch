using Contour.CleanArchitecture.UseCases.Projects;
using Contour.CleanArchitecture.UseCases.Projects.ListIncompleteItems;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Contour.CleanArchitecture.Infrastructure.Data.Queries;

public class ListIncompleteItemsQueryService(AppDbContext db) : IListIncompleteItemsQueryService
{
  public async Task<IEnumerable<ToDoItemDTO>> ListAsync(int projectId)
  {
    var projectParameter = new SqlParameter("@projectId", System.Data.SqlDbType.Int);
    var result = await db.ToDoItems.FromSqlRaw("SELECT Id, Title, Description, IsDone, ContributorId FROM ToDoItems WHERE ProjectId = @ProjectId", projectParameter)
      .Select(x => new ToDoItemDTO(x.Id, x.Title, x.Description, x.IsDone, x.ContributorId))
      .ToListAsync();

    return result;
  }
}
