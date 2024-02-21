using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Core.ContributorAggregate;

namespace Contour.CleanArchitecture.UseCases.Contributors.Update;

public class UpdateContributorHandler(IRepository<Contributor> repository)
  : ICommandHandler<UpdateContributorCommand, Result<ContributorDTO>>
{
  public async Task<Result<ContributorDTO>> Handle(UpdateContributorCommand request, CancellationToken cancellationToken)
  {
    var existingContributor = await repository.GetByIdAsync(request.ContributorId, cancellationToken);
    if (existingContributor == null)
    {
      return Result.NotFound();
    }

    existingContributor.UpdateName(request.NewName!);

    await repository.UpdateAsync(existingContributor, cancellationToken);

    return Result.Success(new ContributorDTO(existingContributor.Id, existingContributor.Name));
  }
}
