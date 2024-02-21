using Ardalis.Result;
using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Core.ContributorAggregate;
using Contour.CleanArchitecture.Core.ContributorAggregate.Specifications;

namespace Contour.CleanArchitecture.UseCases.Contributors.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetContributorHandler(IReadRepository<Contributor> repository)
  : IQueryHandler<GetContributorQuery, Result<ContributorDTO>>
{
  public async Task<Result<ContributorDTO>> Handle(GetContributorQuery request, CancellationToken cancellationToken)
  {
    var spec = new ContributorByIdSpec(request.ContributorId);
    var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ContributorDTO(entity.Id, entity.Name);
  }
}
