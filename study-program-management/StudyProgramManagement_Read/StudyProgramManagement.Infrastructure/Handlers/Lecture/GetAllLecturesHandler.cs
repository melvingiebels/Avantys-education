using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Lecture;

namespace StudyProgramManagement.Infrastructure.Handlers.Lecture;

public class GetAllLecturesHandler: MongoQueryBase<LectureCollection>, IGetAllLectures
{
    public GetAllLecturesHandler(LectureCollection collection) : base(collection)
    {
    }

    public IEnumerable<LectureSchema> Excecute()
    {
        return Collection.MongoClient.Database.GetCollection<LectureSchema>("LectureSchema").Find(_ => true).ToList();
    }
}