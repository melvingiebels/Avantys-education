using System.ComponentModel.DataAnnotations;

namespace CQS.Domain;

public class StudentsTests
{
    [Key] public Guid Id { get; set; }
    public Guid TestId { get; set; }
    public Guid StudentId { get; set; }
    public double? Grade { get; set; }

    public StudentsTests(Guid id, Guid testId, double? grade)
    {
        Id = id;
        TestId = testId;
        Grade = grade;
    }
}