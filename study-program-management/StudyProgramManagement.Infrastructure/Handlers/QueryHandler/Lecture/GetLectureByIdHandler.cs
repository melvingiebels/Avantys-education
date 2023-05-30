using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Lecture;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Lecture;

public class GetLectureByIdHandler : MongoQueryBase<LectureCollection>, IGetLectureById
{
    public GetLectureByIdHandler(LectureCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.Lecture> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.Lecture>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}