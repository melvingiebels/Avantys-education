using System;
using System.Collections.Generic;

namespace StudyProgramManagement.Domain.Schemas;

public class TeacherSchema
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ModuleSchema> Modules { get; set; }

    public TeacherSchema(string firstName, string lastName, List<ModuleSchema> modules)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        Modules = modules;
    }

    public TeacherSchema()
    {
    }
}