using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestManagement.CQS.Domain.Questions;

public class McQuestion : Question
{
    public McQuestion(string statement, string correctOption) : base(statement, correctOption)
    {
        Options = new[] { "a", "b", "c", "d" };
    }

    public McQuestion()
    {
    }

    [NotMapped] [JsonIgnore] public string[]? Options { get; set; }
}