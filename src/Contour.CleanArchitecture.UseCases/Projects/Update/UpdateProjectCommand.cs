using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.UseCases.Projects.Update;

public record UpdateProjectCommand(int ProjectId, string NewName) : ICommand<Result<ProjectDTO>>;
