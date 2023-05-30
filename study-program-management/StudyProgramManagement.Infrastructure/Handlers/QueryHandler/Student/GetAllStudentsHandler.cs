using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Student;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Student;

public class GetAllStudentsHandler: MongoQueryBase<StudentCollection>, IGetAllStudents
{
    public GetAllStudentsHandler(StudentCollection collection) : base(collection)
    {
    }

    public IEnumerable<Domain.Models.Student> Excecute()
    {
        return Collection.Collection.Find(p => true).ToList();
    }
}