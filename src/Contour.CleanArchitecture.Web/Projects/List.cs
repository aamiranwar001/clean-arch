using Contour.CleanArchitecture.Domain.ProjectAggregate;
using Contour.CleanArchitecture.UseCases.Projects.ListShallow;
using FastEndpoints;
using MediatR;

namespace Contour.CleanArchitecture.Web.Projects;
/// <summary>
/// Lists all projects without their sub-properties.
/// </summary>
/// <remarks>
/// Lists all projects without their sub-properties.
/// NOTE: In DEV will always show a FAKE ID 1000 project, not real data
/// </remarks>
public class List(IMediator mediator) : EndpointWithoutRequest<ProjectListResponse>
{
  public override void Configure()
  {
    Get($"/{nameof(Project)}s");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var result = await mediator.Send(new ListProjectsShallowQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new ProjectListResponse
      {
        Projects = result.Value.Select(c => new ProjectRecord(c.Id, c.Name)).ToList()
      };
    }
  }
}
