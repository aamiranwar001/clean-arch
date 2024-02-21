namespace Contour.CleanArchitecture.Core.ProjectAggregate;

public enum ProjectStatus
{
  InProgress, // NOTE: Better to use a SmartEnum if you want spaces in your strings e.g. "In Progress"
  Complete
}
