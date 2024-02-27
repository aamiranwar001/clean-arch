using Ardalis.SharedKernel;
using Contour.CleanArchitecture.Domain.ContributorAggregate.Events;
using Contour.CleanArchitecture.Domain.ProjectAggregate;
using Contour.CleanArchitecture.Domain.ProjectAggregate.Specifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contour.CleanArchitecture.Domain.ContributorAggregate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class ContributorDeletedHandler(IRepository<Project> _repository, ILogger<ContributorDeletedHandler> _logger) : INotificationHandler<ContributorDeletedEvent>
{
  public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Removing deleted contributor {contributorId} from all projects...", domainEvent.ContributorId);
    // Perform eventual consistency removal of contributors from projects when one is deleted
    var projectSpec = new ProjectsWithItemsByContributorIdSpec(domainEvent.ContributorId);
    var projects = await _repository.ListAsync(projectSpec, cancellationToken);
    foreach (var project in projects)
    {
      project.Items
        .Where(item => item.ContributorId == domainEvent.ContributorId)
        .ToList()
        .ForEach(item => item.RemoveContributor());
      await _repository.UpdateAsync(project, cancellationToken);
    }
  }
}
