namespace StudyProgramManagement.Domain.Models;

public class Module
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Blok Block { get; set; }
    public List<Lecture> Lectures { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Class> Classes { get; set; }

    public Module(List<Lecture> lectures, List<Teacher> teachers, string name, Blok block, List<Class> classes)
    {
        Id = new Guid();
        Lectures = lectures;
        Teachers = teachers;
        Name = name;
        Block = block;
        Classes = classes;
    }
}

