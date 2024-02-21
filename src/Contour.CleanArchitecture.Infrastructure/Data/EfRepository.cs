﻿using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.SharedKernel;

namespace Contour.CleanArchitecture.Infrastructure.Data;

public class EfRepository<T>(AppDbContext dbContext)
  : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
}
