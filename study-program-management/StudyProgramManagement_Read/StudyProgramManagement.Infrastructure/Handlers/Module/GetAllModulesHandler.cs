using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Module;

namespace StudyProgramManagement.Infrastructure.Handlers.Module;

public class GetAllModulesHandler: MongoQueryBase<ModuleCollection>, IGetAllModules
{
    public GetAllModulesHandler(ModuleCollection collection) : base(collection)
    {
    }

    public IEnumerable<ModuleSchema> Excecute()
    {
        return Collection.MongoClient.Database.GetCollection<ModuleSchema>("ModuleSchema").Find(_ => true).ToList();
    }
}