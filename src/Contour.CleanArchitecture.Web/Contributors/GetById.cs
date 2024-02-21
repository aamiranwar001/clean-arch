using FastEndpoints;
using MediatR;
using Ardalis.Result;
using Contour.CleanArchitecture.Web.Endpoints.ContributorEndpoints;
using Contour.CleanArchitecture.UseCases.Contributors.Get;

namespace Contour.CleanArchitecture.Web.ContributorEndpoints;

/// <summary>
/// Get a Contributor by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Contributor record.
/// </remarks>
public class GetById(IMediator mediator) : Endpoint<GetContributorByIdRequest, ContributorRecord>
{
  public override void Configure()
  {
    Get(GetContributorByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetContributorByIdRequest request, CancellationToken cancellationToken)
  {
    var command = new GetContributorQuery(request.ContributorId);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new ContributorRecord(result.Value.Id, result.Value.Name);
    }
  }
}
