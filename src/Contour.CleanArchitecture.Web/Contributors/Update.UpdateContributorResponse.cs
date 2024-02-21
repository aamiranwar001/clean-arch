using Contour.CleanArchitecture.Web.ContributorEndpoints;

namespace Contour.CleanArchitecture.Web.Endpoints.ContributorEndpoints;

public class UpdateContributorResponse(ContributorRecord contributor)
{
  public ContributorRecord Contributor { get; set; } = contributor;
}
