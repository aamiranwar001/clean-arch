using Contour.CleanArchitecture.Web.ContributorEndpoints;

namespace Contour.CleanArchitecture.Web.Endpoints.ContributorEndpoints;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = new();
}
