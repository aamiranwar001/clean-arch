using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Domain.ContributorAggregate;

namespace Contour.CleanArchitecture.UseCases.Contributors.Create;

public class CreateContributorHandler(IRepository<Contributor> repository)
  : ICommandHandler<CreateContributorCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateContributorCommand request, CancellationToken cancellationToken)
  {
    var newContributor = new Contributor(request.Name);
    var createdItem = await repository.AddAsync(newContributor, cancellationToken);

    return createdItem.Id;
  }
}
