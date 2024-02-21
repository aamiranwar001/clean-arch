using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.UseCases.Projects.GetWithAllItems;

public record GetProjectWithAllItemsQuery(int ProjectId) : IQuery<Result<ProjectWithAllItemsDTO>>;
