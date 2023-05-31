using System;
using System.Collections.Generic;

namespace StudyProgramManagement.Domain.Schemas;

public class StudyProgramSchema
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int TotalECs { get; set; }
    public List<ModuleSchema> Modules { get; set; }
    public List<StudentSchema> Students { get; set; }
    public StudyProgramSchema(int totalECs, List<ModuleSchema> modules, List<StudentSchema> students, string name, string code)
    {
        Id = new Guid();
        TotalECs = totalECs;
        Modules = modules;
        Students = students;
        Name = name;
        Code = code;
    }

    public StudyProgramSchema()
    {
        
    }
}