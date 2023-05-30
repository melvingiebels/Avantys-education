using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Student;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Student;

public class GetStudentByIdHandler: MongoQueryBase<StudentCollection>, IGetStudentById
{
    public GetStudentByIdHandler(StudentCollection collection) : base(collection)
    {
    }

    public async Task<StudentSchema> Excecute(Guid id)
    {
        var filter = Builders<StudentSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}