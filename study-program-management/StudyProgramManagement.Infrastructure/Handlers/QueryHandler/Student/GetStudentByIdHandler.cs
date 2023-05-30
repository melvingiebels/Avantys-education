using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Student;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Student;

public class GetStudentByIdHandler: MongoQueryBase<StudentCollection>, IGetStudentById
{
    public GetStudentByIdHandler(StudentCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.Student> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.Student>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}