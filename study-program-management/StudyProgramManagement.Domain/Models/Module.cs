using System.Text.Json.Serialization;
using StudyProgramManagement.Domain.Models.Enums;

namespace StudyProgramManagement.Domain.Models;

public class Module
{
    public Guid Id { get; set; }
    public int ECs { get; set; }
    public string Name { get; set; }
    public Block Block { get; set; }
    [JsonIgnore]
    public List<Lecture> Lectures { get; set; }
    [JsonIgnore]
    public List<Teacher> Teachers { get; set; }
    [JsonIgnore]
    public List<Class> Classes { get; set; }

    public Module(List<Lecture> lectures, List<Teacher> teachers, string name, Block block, List<Class> classes,
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

    public Module()
    {
    }
}