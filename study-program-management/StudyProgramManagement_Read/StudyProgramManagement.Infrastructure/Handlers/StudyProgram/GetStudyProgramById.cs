using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.StudyProgram;

namespace StudyProgramManagement.Infrastructure.Handlers.StudyProgram;

public class GetStudyProgramById: MongoQueryBase<StudyProgramCollection>, IGetStudyProgramById
{
    public GetStudyProgramById(StudyProgramCollection collection) : base(collection)
    {
    }

    public async Task<StudyProgramSchema> Excecute(Guid id)
    {
        var filter = Builders<StudyProgramSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.MongoClient.Database.GetCollection<StudyProgramSchema>("StudyProgramSchema").Find(filter).FirstOrDefaultAsync();
    }
}