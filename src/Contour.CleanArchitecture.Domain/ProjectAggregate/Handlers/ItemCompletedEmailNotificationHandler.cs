using Ardalis.GuardClauses;
using Contour.CleanArchitecture.Domain.Interfaces;
using Contour.CleanArchitecture.Domain.ProjectAggregate.Events;
using MediatR;

namespace Contour.CleanArchitecture.Domain.ProjectAggregate.Handlers;

public class ItemCompletedEmailNotificationHandler(IEmailSender emailSender) : INotificationHandler<ToDoItemCompletedEvent>
{
  private readonly IEmailSender _emailSender = emailSender;

  public Task Handle(ToDoItemCompletedEvent domainEvent, CancellationToken cancellationToken)
  {
    Guard.Against.Null(domainEvent, nameof(domainEvent));

    return _emailSender.SendEmailAsync("test@test.com", "test@test.com", $"{domainEvent.CompletedItem.Title} was completed.", domainEvent.CompletedItem.ToString());
  }
}
