using Contour.CleanArchitecture.Web.ContributorEndpoints;

namespace Contour.CleanArchitecture.Web.Endpoints.ContributorEndpoints;

public class UpdateContributorResponse
{
  public UpdateContributorResponse(ContributorRecord contributor)
  {
    Contributor = contributor;
  }
  public ContributorRecord Contributor { get; set; }
}
