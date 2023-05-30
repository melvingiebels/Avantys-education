using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Teacher;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Teacher;

public class GetAllTeachersHandler: MongoQueryBase<TeacherCollection>, IGetAllTeachers
{
    public GetAllTeachersHandler(TeacherCollection collection) : base(collection)
    {
    }

    public IEnumerable<Domain.Models.Teacher> Excecute()
    {
        return Collection.Collection.Find(p => true).ToList();
    }
}