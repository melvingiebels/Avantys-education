using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Commands.RabbitMq.Handlers;

public class EnrollmentAcceptedHandler : MessageHandler<Student>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public EnrollmentAcceptedHandler(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Handle(Student? model)
    {
        _dbContext.Students.Add(model!);
        _dbContext.SaveChanges();
    }
}