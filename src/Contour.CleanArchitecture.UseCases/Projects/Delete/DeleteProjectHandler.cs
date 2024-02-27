using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Domain.ProjectAggregate;

namespace Contour.CleanArchitecture.UseCases.Projects.Delete;

public class DeleteProjectHandler(IRepository<Project> repository) : ICommandHandler<DeleteProjectCommand, Result>
{
  public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
  {
    var aggregateToDelete = await repository.GetByIdAsync(request.ProjectId, cancellationToken);
    if (aggregateToDelete == null)
    {
      return Result.NotFound();
    }

    await repository.DeleteAsync(aggregateToDelete, cancellationToken);

    return Result.Success();
  }
}
