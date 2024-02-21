using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Core.ProjectAggregate;
using Contour.CleanArchitecture.Core.ProjectAggregate.Specifications;

namespace Contour.CleanArchitecture.UseCases.Projects.AddToDoItem;

public class AddToDoItemHandler(IRepository<Project> repository) : ICommandHandler<AddToDoItemCommand, Result<int>>
{
  public async Task<Result<int>> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      return Result.NotFound();
    }

    var newItem = new ToDoItem()
    {
      Title = request.Title!,
      Description = request.Description!
    };

    if (request.ContributorId.HasValue)
    {
      newItem.AddContributor(request.ContributorId.Value);
    }
    entity.AddItem(newItem);
    await repository.UpdateAsync(entity);

    return Result.Success(newItem.Id);
  }
}
