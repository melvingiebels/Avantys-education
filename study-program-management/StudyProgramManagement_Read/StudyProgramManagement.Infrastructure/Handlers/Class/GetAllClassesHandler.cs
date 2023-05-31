using System.Collections.Generic;
using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Class;

namespace StudyProgramManagement.Infrastructure.Handlers.Class;

public class GetAllClassesHandler: MongoQueryBase<ClassCollection>, IGetAllClasses
{
    public GetAllClassesHandler(ClassCollection collection) : base(collection)
    {
    }

    public IEnumerable<ClassSchema> Excecute()
    {
        return Collection.Collection.Find(_ => true).ToList();
    }
}   