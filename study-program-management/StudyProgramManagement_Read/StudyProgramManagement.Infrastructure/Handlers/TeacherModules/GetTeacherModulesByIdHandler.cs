using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.TeacherModules;

namespace StudyProgramManagement.Infrastructure.Handlers.TeacherModules;

public class GetTeacherModulesByIdHandler: MongoQueryBase<TeacherModulesCollection>, IGetTeacherModuleById
{
    public GetTeacherModulesByIdHandler(TeacherModulesCollection collection) : base(collection)
    {
    }

    public async Task<TeacherModulesSchema> Excecute(Guid id)
    {
        var filter = Builders<TeacherModulesSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}