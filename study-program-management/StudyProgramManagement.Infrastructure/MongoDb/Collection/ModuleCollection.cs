using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class ModuleCollection: MongoCollection<ModuleSchema>
{
    public ModuleCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}