using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.TeacherModules;

namespace StudyProgramManagement.Infrastructure.Handlers.TeacherModules;

public class GetAllTeacherModulesHandler: MongoQueryBase<TeacherModulesCollection>, IGetAllTeacherModules
{
    public GetAllTeacherModulesHandler(TeacherModulesCollection collection) : base(collection)
    {
    }

    public IEnumerable<TeacherModulesSchema> Excecute()
    {
        return Collection.Collection.Find(p => true).ToList();
    }
}