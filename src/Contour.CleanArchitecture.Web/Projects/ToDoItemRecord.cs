namespace Contour.CleanArchitecture.Web.Projects;

public record ToDoItemRecord(int Id, string Title, string Description, bool IsDone, int? ContributorId);
