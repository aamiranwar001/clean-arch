using Ardalis.Result;
using Contour.CleanArchitecture.UseCases.Projects.GetWithAllItems;
using FastEndpoints;
using MediatR;

namespace Contour.CleanArchitecture.Web.Projects;

public class GetById(IMediator mediator) : Endpoint<GetProjectByIdRequest, GetProjectByIdResponse>
{
  public override void Configure()
  {
    Get(GetProjectByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetProjectByIdRequest request, CancellationToken ct)
  {
    var command = new GetProjectWithAllItemsQuery(request.ProjectId);

    var result = await mediator.Send(command, ct);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new GetProjectByIdResponse(result.Value.Id,
        result.Value.Name,
        items:
        result.Value.Items
          .Select(item => new ToDoItemRecord(
            item.Id,
            item.Title,
            item.Description,
            item.IsComplete,
            item.ContributorId
            ))
          .ToList());
    }
  }
}
