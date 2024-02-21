using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.UseCases.Projects.ListShallow;

public record ListProjectsShallowQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ProjectDTO>>>;
