using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Student;

namespace StudyProgramManagement.Infrastructure.Handlers.Student;

public class GetAllStudentsHandler: MongoQueryBase<StudentCollection>, IGetAllStudents
{
    public GetAllStudentsHandler(StudentCollection collection) : base(collection)
    {
    }

    public IEnumerable<StudentSchema> Excecute()
    {
        return Collection.Collection.Find(p => true).ToList();
    }
}