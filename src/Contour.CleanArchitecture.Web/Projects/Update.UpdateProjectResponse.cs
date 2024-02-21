namespace Contour.CleanArchitecture.Web.Projects;

public class UpdateProjectResponse(ProjectRecord project)
{
  public ProjectRecord Project { get; set; } = project;
}
