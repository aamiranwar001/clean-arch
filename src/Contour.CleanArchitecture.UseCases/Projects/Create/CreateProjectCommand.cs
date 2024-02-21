using Ardalis.Result;

namespace Contour.CleanArchitecture.UseCases.Projects.Create;

/// <summary>
/// Create a new Project.
/// </summary>
/// <param name="Name"></param>
public record CreateProjectCommand(string Name) : Ardalis.SharedKernel.ICommand<Result<int>>;
