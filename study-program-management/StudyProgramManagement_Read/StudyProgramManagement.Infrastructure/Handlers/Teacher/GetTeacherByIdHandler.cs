using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Teacher;

namespace StudyProgramManagement.Infrastructure.Handlers.Teacher;

public class GetTeacherByIdHandler: MongoQueryBase<TeacherCollection>, IGetTeacherById
{
    public GetTeacherByIdHandler(TeacherCollection collection) : base(collection)
    {
    }

    public async Task<TeacherSchema> Excecute(Guid id)
    {
        var filter = Builders<TeacherSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.MongoClient.Database.GetCollection<TeacherSchema>("TeacherSchema").Find(filter).FirstOrDefaultAsync();
    }
}