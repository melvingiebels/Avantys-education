using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.TeacherModules;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.TeacherModules;

public class GetTeacherModulesByIdHandler: MongoQueryBase<TeacherModulesCollection>, IGetTeacherModuleById
{
    public GetTeacherModulesByIdHandler(TeacherModulesCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.TeacherModules> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.TeacherModules>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}