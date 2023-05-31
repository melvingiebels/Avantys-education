using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Module;

namespace StudyProgramManagement.Infrastructure.Handlers.Module;

public class GetModuleByIdHandler: MongoQueryBase<ModuleCollection>, IGetModuleById
{
    public GetModuleByIdHandler(ModuleCollection collection) : base(collection)
    {
    }

    public async Task<ModuleSchema> Excecute(Guid id)
    {
        var filter = Builders<ModuleSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}