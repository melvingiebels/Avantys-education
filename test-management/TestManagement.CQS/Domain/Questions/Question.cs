using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestManagement.CQS.Domain.Questions;

public abstract class Question
{
    protected Question(string statement, string answer)
    {
        Statement = statement;
        Answer = answer;
        Id = new Guid();
    }

    protected Question()
    {
    }

    [Key] public Guid Id { get; set; }
    [JsonIgnore] [NotMapped] public List<Test>? Tests { get; set; }
    public string Statement { get; set; }
    public string Answer { get; set; }
}