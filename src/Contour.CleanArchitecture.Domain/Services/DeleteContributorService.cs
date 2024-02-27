using Ardalis.Result;
using Contour.CleanArchitecture.Domain.ContributorAggregate;
using Contour.CleanArchitecture.Domain.ContributorAggregate.Events;
using Contour.CleanArchitecture.Domain.Interfaces;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contour.CleanArchitecture.Domain.Services;

public class DeleteContributorService(IRepository<Contributor> _repository,
  IMediator _mediator,
  ILogger<DeleteContributorService> _logger) : IDeleteContributorService
{
  public async Task<Result> DeleteContributor(int contributorId)
  {
    _logger.LogInformation("Deleting Contributor {contributorId}", contributorId);
    var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ContributorDeletedEvent(contributorId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
