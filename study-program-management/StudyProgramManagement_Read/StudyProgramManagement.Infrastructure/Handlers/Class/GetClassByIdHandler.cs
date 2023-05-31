using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Class;

namespace StudyProgramManagement.Infrastructure.Handlers.Class;

public class GetClassByIdHandler: MongoQueryBase<ClassCollection>, IGetClassById
{
    public GetClassByIdHandler(ClassCollection collection) : base(collection)
    {
    }

    public async Task<ClassSchema> Excecute(Guid id)
    {
        var filter = Builders<ClassSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}