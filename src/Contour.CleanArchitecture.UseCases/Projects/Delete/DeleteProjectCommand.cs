using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.UseCases.Projects.Delete;

public record DeleteProjectCommand(int ProjectId) : ICommand<Result>;
