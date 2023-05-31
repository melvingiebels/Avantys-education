using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Lecture;

namespace StudyProgramManagement.Infrastructure.Handlers.Lecture;

public class GetLectureByIdHandler : MongoQueryBase<LectureCollection>, IGetLectureById
{
    public GetLectureByIdHandler(LectureCollection collection) : base(collection)
    {
    }

    public async Task<LectureSchema> Excecute(Guid id)
    {
        var filter = Builders<LectureSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}