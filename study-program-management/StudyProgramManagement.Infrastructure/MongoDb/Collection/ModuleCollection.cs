using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class ModuleCollection: MongoCollection<Module>
{
    public ModuleCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}