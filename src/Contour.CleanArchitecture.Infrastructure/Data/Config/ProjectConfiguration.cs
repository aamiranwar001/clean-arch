using Contour.CleanArchitecture.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contour.CleanArchitecture.Infrastructure.Data.Config;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  public void Configure(EntityTypeBuilder<Project> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(p => p.Priority)
      .HasConversion(
          p => p.Value,
          p => PriorityStatus.FromValue(p));
  }
}
