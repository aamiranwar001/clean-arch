namespace Contour.CleanArchitecture.Web.Projects;

public class CreateProjectResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
