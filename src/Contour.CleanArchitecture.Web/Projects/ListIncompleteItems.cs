using Ardalis.Result;
using Contour.CleanArchitecture.UseCases.Projects.ListIncompleteItems;
using Contour.CleanArchitecture.Web.ProjectEndpoints;
using FastEndpoints;
using MediatR;

namespace Contour.CleanArchitecture.Web.Projects;

/// <summary>
/// Lists all incomplete items in a project.
/// </summary>
/// <remarks>
/// Lists all incomplete items in a project.
/// Returns FAKE data in DEV. Run in production to use real database-driven data.
/// </remarks>
public class ListIncompleteItems(IMediator mediator) : Endpoint<ListIncompleteItemsRequest, ListIncompleteItemsResponse>
{
  public override void Configure()
  {
    Get(ListIncompleteItemsRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(ListIncompleteItemsRequest request, CancellationToken ct)
  {
    Response = new ListIncompleteItemsResponse(request.ProjectId, []);

    var result = await mediator.Send(new ListIncompleteItemsByProjectQuery(request.ProjectId), ct);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    Response.IncompleteItems = result.Value.Select(item =>
                    new ToDoItemRecord(item.Id, item.Title, item.Description, item.IsComplete, item.ContributorId))
                    .ToList();
  }
}
