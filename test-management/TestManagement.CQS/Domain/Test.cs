using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TestManagement.CQS.Domain.Questions;

namespace TestManagement.CQS.Domain;

public class Test
{
    public Test(List<Question> questions, string module)
    {
        Id = new Guid();
        Questions = questions;
        Module = module;
    }

    public Test()
    {
    }

    [Key] public Guid Id { get; set; }
    [JsonIgnore] public List<Question>? Questions { get; set; }
    [JsonIgnore] [NotMapped] public List<Student> Students { get; set; }

    public string Module { get; set; }
    public double? Grade { get; set; }
}