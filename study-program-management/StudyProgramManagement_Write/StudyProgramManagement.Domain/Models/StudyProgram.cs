using System;
using System.Collections.Generic;

namespace StudyProgramManagement.Domain.Models;

public class StudyProgram : Model
{
    public StudyProgram(int totalECs, List<Module> modules, List<Student> students, string name, string code)
    {
        Id = new Guid();
        TotalECs = totalECs;
        Modules = modules;
        Students = students;
        Name = name;
        Code = code;
    }

    public StudyProgram()
    {
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int TotalECs { get; set; }
    public List<Module> Modules { get; set; }
    public List<Student> Students { get; set; }
}