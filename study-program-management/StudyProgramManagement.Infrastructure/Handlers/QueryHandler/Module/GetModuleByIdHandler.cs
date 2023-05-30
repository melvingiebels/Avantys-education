using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Module;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Module;

public class GetModuleByIdHandler: MongoQueryBase<ModuleCollection>, IGetModuleById
{
    public GetModuleByIdHandler(ModuleCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.Module> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.Module>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}