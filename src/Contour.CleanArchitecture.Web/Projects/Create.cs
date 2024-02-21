using Contour.CleanArchitecture.UseCases.Projects.Create;
using FastEndpoints;
using MediatR;

namespace Contour.CleanArchitecture.Web.Projects;

/// <summary>
/// Creates a new Project
/// </summary>
/// <remarks>
/// Creates a new project given a name.
/// </remarks>
public class Create(IMediator mediator) : Endpoint<CreateProjectRequest, CreateProjectResponse>
{
  public override void Configure()
  {
    Post(CreateProjectRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateProjectRequest { Name = "Project Name" };
    });
  }

  public override async Task HandleAsync(CreateProjectRequest request, CancellationToken ct)
  {
    var result = await mediator.Send(new CreateProjectCommand(request.Name!), ct);

    if (result.IsSuccess)
    {
      Response = new CreateProjectResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
