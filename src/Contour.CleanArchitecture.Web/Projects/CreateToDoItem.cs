using Contour.CleanArchitecture.UseCases.Projects.AddToDoItem;
using Contour.CleanArchitecture.Web.Projects;
using FastEndpoints;
using MediatR;

namespace Contour.CleanArchitecture.Web.ProjectEndpoints;

public class Create(IMediator mediator) : Endpoint<CreateToDoItemRequest>
{
  public override void Configure()
  {
    Post(CreateToDoItemRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateToDoItemRequest
      {
        ContributorId = 1,
        ProjectId = 1,
        Title = "Title",
        Description = "Description"
      };
    });
  }

  public override async Task HandleAsync(CreateToDoItemRequest request, CancellationToken ct)
  {
    var command = new AddToDoItemCommand(request.ProjectId, request.ContributorId, request.Title, request.Description);
    var result = await mediator.Send(command, ct);

    if (result.Status == Ardalis.Result.ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    if (result.IsSuccess)
    {
      // send route to project
      await SendCreatedAtAsync<GetById>(new { projectId = request.ProjectId }, "", cancellation: ct);
    }
    // TODO: Handle other cases as necessary
  }
}
