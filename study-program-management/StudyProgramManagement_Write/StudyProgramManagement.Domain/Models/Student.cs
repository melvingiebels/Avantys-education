using System;

namespace StudyProgramManagement.Domain.Models;

public class Student : Model
{
    public Student(string firstName, string lastName, Guid studyProgramId)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        StudyProgramId = studyProgramId;
    }

    public Student()
    {
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid StudyProgramId { get; set; }
}