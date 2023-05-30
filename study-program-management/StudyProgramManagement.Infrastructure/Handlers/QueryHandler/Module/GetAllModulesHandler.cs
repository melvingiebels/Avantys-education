using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Module;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Module;

public class GetAllModulesHandler: MongoQueryBase<ModuleCollection>, IGetAllModules
{
    public GetAllModulesHandler(ModuleCollection collection) : base(collection)
    {
    }

    public IEnumerable<Domain.Models.Module> Excecute()
    {
        return Collection.Collection.Find(p => true).ToList();
    }
}