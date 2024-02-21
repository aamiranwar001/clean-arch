using System.ComponentModel.DataAnnotations;

namespace Contour.CleanArchitecture.Web.Projects;

public class CreateProjectRequest
{
  public const string Route = "/Projects";

  [Required]
  public string? Name { get; set; }
}
