using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.StudyProgram;

namespace StudyProgramManagement.Infrastructure.Handlers.StudyProgram;

public class GetAllStudyProgramsHandler: MongoQueryBase<StudyProgramCollection>, IGetAllStudyPrograms
{
    public GetAllStudyProgramsHandler(StudyProgramCollection collection) : base(collection)
    {
    }

    public IEnumerable<StudyProgramSchema> Excecute()
    {
        return Collection.MongoClient.Database.GetCollection<StudyProgramSchema>("StudyProgramSchema").Find(_ => true).ToList();
    }
}