using FastEndpoints;
using MediatR;
using Ardalis.Result;
using Contour.CleanArchitecture.UseCases.Projects.Update;

namespace Contour.CleanArchitecture.Web.Projects;

public class Update(IMediator mediator) : Endpoint<UpdateProjectRequest, UpdateProjectResponse>
{
  public override void Configure()
  {
    Put(UpdateProjectRequest.Route);
    AllowAnonymous();
  }


  public override async Task HandleAsync(UpdateProjectRequest request, CancellationToken ct)
  {
    var result = await mediator.Send(new UpdateProjectCommand(request.Id, request.Name!), ct);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    if (result.IsSuccess)
    {
      var dto = result.Value;
      Response = new UpdateProjectResponse(new ProjectRecord(dto.Id, dto.Name));
      return;
    }
  }
}
