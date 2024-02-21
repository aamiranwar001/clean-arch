using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Core.ProjectAggregate;

namespace Contour.CleanArchitecture.UseCases.Projects.Update;

public class UpdateProjectHandler(IRepository<Project> repository) : ICommandHandler<UpdateProjectCommand, Result<ProjectDTO>>
{
  public async Task<Result<ProjectDTO>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
  {
    var existingEntity = await repository.GetByIdAsync(request.ProjectId, cancellationToken);
    if (existingEntity == null)
    {
      return Result.NotFound();
    }

    existingEntity.UpdateName(request.NewName!);

    await repository.UpdateAsync(existingEntity, cancellationToken);

    return Result.Success(new ProjectDTO(existingEntity.Id, existingEntity.Name, existingEntity.Status.ToString()));
  }
}
