﻿using TestManagement.CQS.Queries;
using Microsoft.EntityFrameworkCore;

namespace TestManagement.Infrastructure.Core;

public abstract class EFQueryBase<TContext> : IQuery
    where TContext : DbContext
{
    protected readonly TContext DbContext;

    protected EFQueryBase(TContext dbContext)
    {
        DbContext = dbContext;
    }
}