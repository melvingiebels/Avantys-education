using System;
using System.Collections.Generic;
using StudyProgramManagement.Domain.Enums;

namespace StudyProgramManagement.Domain.Schemas;

public class ClassSchema
{
    public Guid Id { get; set; }
    public List<StudentSchema> Students { get; set; }
    public ClassNotation ClassNotation { get; set; }

    public ClassSchema(List<StudentSchema> students, ClassNotation classNotation)
    {
        Students = students;
        ClassNotation = classNotation;
    }

    public ClassSchema()
    {
    }
}