namespace Contour.CleanArchitecture.Web.Projects;

public class ListIncompleteItemsResponse(int projectId, List<ToDoItemRecord> incompleteItems)
{
  public int ProjectId { get; set; } = projectId;
  public List<ToDoItemRecord> IncompleteItems { get; set; } = incompleteItems;
}
