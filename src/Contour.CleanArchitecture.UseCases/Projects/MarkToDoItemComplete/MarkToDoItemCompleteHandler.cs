using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Domain.ProjectAggregate;
using Contour.CleanArchitecture.Domain.ProjectAggregate.Specifications;

namespace Contour.CleanArchitecture.UseCases.Projects.MarkToDoItemComplete;

public class MarkToDoItemCompleteHandler(IRepository<Project> repository) : ICommandHandler<MarkToDoItemCompleteCommand, Result>
{
  public async Task<Result> Handle(MarkToDoItemCompleteCommand request, CancellationToken cancellationToken)
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound("Project not found.");

    var item = entity.Items.FirstOrDefault(i => i.Id == request.ToDoItemId);
    if (item == null) return Result.NotFound("Item not found.");

    item.MarkComplete();
    await repository.UpdateAsync(entity, cancellationToken);

    return Result.Success();
  }
}
