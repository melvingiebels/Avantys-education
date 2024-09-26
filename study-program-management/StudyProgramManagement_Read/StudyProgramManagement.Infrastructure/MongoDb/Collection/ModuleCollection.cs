using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class ModuleCollection: MongoCollection<ModuleSchema>
{
    public ModuleCollection(MongoDbClient mongoDb) : base(mongoDb)
    {
    }
}