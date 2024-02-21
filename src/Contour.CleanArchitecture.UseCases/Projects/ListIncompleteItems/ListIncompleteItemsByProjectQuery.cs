using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.UseCases.Projects.ListIncompleteItems;

public record ListIncompleteItemsByProjectQuery(int ProjectId) : IQuery<Result<IEnumerable<ToDoItemDTO>>>;
