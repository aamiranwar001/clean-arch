﻿using FastEndpoints;
using Contour.CleanArchitecture.Web.Endpoints.ContributorEndpoints;
using Contour.CleanArchitecture.UseCases.Contributors.Create;
using MediatR;

namespace Contour.CleanArchitecture.Web.ContributorEndpoints;

/// <summary>
/// Create a new Contributor
/// </summary>
/// <remarks>
/// Creates a new Contributor given a name.
/// </remarks>
public class Create(IMediator mediator) : Endpoint<CreateContributorRequest, CreateContributorResponse>
{
  public override void Configure()
  {
    Post(CreateContributorRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Contributor.";
      //s.Description = "Create a new Contributor. A valid name is required.";
      s.ExampleRequest = new CreateContributorRequest { Name = "Contributor Name" };
    });
  }

  public override async Task HandleAsync(CreateContributorRequest request, CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new CreateContributorCommand(request.Name!));

    if (result.IsSuccess)
    {
      Response = new CreateContributorResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
