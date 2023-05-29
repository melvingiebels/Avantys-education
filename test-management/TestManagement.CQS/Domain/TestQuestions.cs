using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestManagement.CQS.Domain;

public class TestQuestions
{
    public TestQuestions(Guid testId, Guid questionId)
    {
        QuestionId = questionId;
        TestId = testId;
    }

    public TestQuestions()
    {
    }

    [Key] public Guid Id { get; set; }

    [NotMapped] public Guid QuestionId { get; set; }

    [NotMapped] public Guid TestId { get; set; }
}