﻿using CQS.Domain.Questions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo.Read;

public class QuestionReadRepository : IReadRepository<Question>
{
    private readonly TestManagementDbContext _dbContext;

    public QuestionReadRepository(TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Question>> Get()
    {
        return _dbContext.Questions.ToListAsync();
    }

    public Task<Question?> GetById(Guid id)
    {
        return _dbContext.Questions.FindAsync(id).AsTask();
    }
}