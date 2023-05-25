namespace CQS;

public class Event : Message
{
    public int Version;
}

public class TestCreated : Event
{
    public readonly Guid Id;

    public TestCreated(Guid id)
    {
        Id = id;
    }
}

public class TestReviewed : Event
{
    public readonly Guid Id;
    public readonly int Score;
    public readonly Guid StudentId;
    public readonly Guid TestId;

    public TestReviewed(Guid id, Guid testId, Guid studentId, int score)
    {
        Id = id;
        TestId = testId;
        StudentId = studentId;
        Score = score;
    }
}

public class QuestionAddedToTest : Event
{
    public readonly Guid Id;
    public readonly Guid QuestionId;
    public readonly Guid TestId;

    public QuestionAddedToTest(Guid id, Guid testId, Guid questionId)
    {
        Id = id;
        TestId = testId;
        QuestionId = questionId;
    }
}

public class QuestionRemovedFromTest : Event
{
    public readonly Guid Id;
    public readonly Guid QuestionId;
    public readonly Guid TestId;

    public QuestionRemovedFromTest(Guid id, Guid testId, Guid questionId)
    {
        Id = id;
        TestId = testId;
        QuestionId = questionId;
    }
}