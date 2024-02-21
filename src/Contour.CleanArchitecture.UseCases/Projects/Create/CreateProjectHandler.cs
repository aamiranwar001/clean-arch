using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Core.ProjectAggregate;

namespace Contour.CleanArchitecture.UseCases.Projects.Create;

public class CreateProjectHandler(IRepository<Project> repository) : ICommandHandler<CreateProjectCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
  {
    var newProject = new Project(request.Name, PriorityStatus.Backlog);
    var createdItem = await repository.AddAsync(newProject, cancellationToken);

    return createdItem.Id;
  }
}
