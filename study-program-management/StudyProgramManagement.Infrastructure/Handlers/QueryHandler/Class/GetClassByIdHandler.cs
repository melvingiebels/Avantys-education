using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Class;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Class;

public class GetClassByIdHandler: MongoQueryBase<ClassCollection>, IGetClassById
{
    public GetClassByIdHandler(ClassCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.Class> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.Class>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}