﻿using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.Teacher;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Teacher;

public class GetAllTeachersHandler: MongoQueryBase<TeacherCollection>, IGetAllTeachers
{
    public GetAllTeachersHandler(TeacherCollection collection) : base(collection)
    {
    }

    public IEnumerable<TeacherSchema> Excecute()
    {
        return Collection.Collection.Find(p => true).ToList();
    }
}