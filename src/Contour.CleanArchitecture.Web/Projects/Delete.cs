using Ardalis.Result;
using Contour.CleanArchitecture.UseCases.Projects.Delete;
using FastEndpoints;
using MediatR;

namespace Contour.CleanArchitecture.Web.Projects;

/// <summary>
/// Deletes a project
/// </summary>
public class Delete(IMediator mediator) : Endpoint<DeleteProjectRequest>
{
  public override void Configure()
  {
    Delete(DeleteProjectRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteProjectRequest request, CancellationToken ct)
  {
    var command = new DeleteProjectCommand(request.ProjectId);

    var result = await mediator.Send(command, ct);

    if (result.Status == ResultStatus.NotFound)
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
