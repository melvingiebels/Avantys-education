namespace StudyProgramManagement.Domain.Models;

public class StudyProgram
{
    public Guid Id { get; set; }
    public int TotalECs { get; set; }
    public List<Module> Modules { get; set; }

    public StudyProgram(int totalECs, List<Module> modules)
    {
        TotalECs = totalECs;
        Modules = modules;
    }

    public StudyProgram()
    {
    }
}