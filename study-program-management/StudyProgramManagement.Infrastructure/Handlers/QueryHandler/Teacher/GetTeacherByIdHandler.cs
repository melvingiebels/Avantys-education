using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Teacher;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Teacher;

public class GetTeacherByIdHandler: MongoQueryBase<TeacherCollection>, IGetTeacherById
{
    public GetTeacherByIdHandler(TeacherCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.Teacher> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.Teacher>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}