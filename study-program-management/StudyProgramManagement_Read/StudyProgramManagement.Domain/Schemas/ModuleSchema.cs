using System;
using System.Collections.Generic;
using StudyProgramManagement.Domain.Enums;

namespace StudyProgramManagement.Domain.Schemas;

public class ModuleSchema
{
    public Guid Id { get; set; }
    public int ECs { get; set; }
    public string Name { get; set; }
    public Block Block { get; set; }
    public List<LectureSchema> Lectures { get; set; }
    public List<TeacherSchema> Teachers { get; set; }
    public List<ClassSchema> Classes { get; set; }

    public ModuleSchema(List<LectureSchema> lectures, List<TeacherSchema> teachers, string name, Block block, List<ClassSchema> classes,
        int eCs)
    {
        Id = new Guid();
        Lectures = lectures;
        Teachers = teachers;
        Name = name;
        Block = block;
        Classes = classes;
        ECs = eCs;
    }

    public ModuleSchema()
    {
    }
}