using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Core.Interfaces;

namespace Contour.CleanArchitecture.UseCases.Contributors.Delete;

public class DeleteContributorHandler(IDeleteContributorService deleteContributorService)
  : ICommandHandler<DeleteContributorCommand, Result>
{
  public async Task<Result> Handle(DeleteContributorCommand request, CancellationToken cancellationToken)
  {
    // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
    // This is my preferred approach
    return await deleteContributorService.DeleteContributor(request.ContributorId);

    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // I prefer using the service above so that "domain" event behavior remains in the domain model (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.ContributorId);
    // if (aggregateToDelete == null) return Result.NotFound();

    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new ContributorDeletedEvent(request.ContributorId);
    // await _mediator.Publish(domainEvent);
    // return Result.Success();
  }
}
