using System;

namespace StudyProgramManagement.Domain.Schemas;

public class StudentSchema
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid StudyProgramId { get; set; }
    public StudentSchema(string firstName, string lastName, Guid studyProgramId)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        StudyProgramId = studyProgramId;
    }

    public StudentSchema()
    {
    }
}