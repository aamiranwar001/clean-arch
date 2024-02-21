using Contour.CleanArchitecture.UseCases.Projects.MarkToDoItemComplete;
using FastEndpoints;
using MediatR;

namespace Contour.CleanArchitecture.Web.Projects;

/// <summary>
/// Mark an item as complete
/// </summary>
public class MarkItemComplete(IMediator mediator) : Endpoint<MarkItemCompleteRequest>
{
  public override void Configure()
  {
    Post(MarkItemCompleteRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new MarkItemCompleteRequest
      {
        ProjectId = 1,
        ToDoItemId = 1
      };
    });
  }

  public override async Task HandleAsync(MarkItemCompleteRequest request, CancellationToken ct)
  {
    var command = new MarkToDoItemCompleteCommand(request.ProjectId, request.ToDoItemId);
    var result = await mediator.Send(command, ct);

    if (result.Status == Ardalis.Result.ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(ct);
    }
    // TODO: Handle other issues as needed
  }

}
