namespace Contour.CleanArchitecture.Web.Projects;

public class GetProjectByIdResponse(int id, string name, List<ToDoItemRecord> items)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
  public List<ToDoItemRecord> Items { get; set; } = items;
}
