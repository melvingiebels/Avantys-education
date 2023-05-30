using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.StudyProgram;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.StudyProgram;

public class GetStudyProgramById: MongoQueryBase<StudyProgramCollection>, IGetStudyProgramById
{
    public GetStudyProgramById(StudyProgramCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.StudyProgram> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.StudyProgram>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}