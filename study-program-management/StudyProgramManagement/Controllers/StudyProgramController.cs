using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class StudyProgramController : ControllerBase
{
    private readonly IRepository<StudyProgram?> _studyProgramRepository;
    private readonly IRepository<Student?> _studentRepository;

    public StudyProgramController(IRepository<StudyProgram?> studyProgramRepository, IRepository<Student?> studentRepository)
    {
        _studyProgramRepository = studyProgramRepository;
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<StudyProgram?>> Get()
    {
        return await _studyProgramRepository.Get();
    }

    [HttpGet("{studyProgramId}")]
    public async Task<StudyProgram?> GetById(Guid studyProgramId)
    {
        return await _studyProgramRepository.GetById(studyProgramId);
    }

    [HttpPost]
    public void Create([FromBody] StudyProgram model)
    {
        _studyProgramRepository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] StudyProgram model)
    {
        _studyProgramRepository.Update(model);
    }
    
    [HttpPut("{studyProgramId}/{studentId}")]
    public void EnrollStudent([FromRoute] Guid studyProgramId, [FromRoute] Guid studentId)
    {
        var studyProgramToEnroll = _studyProgramRepository.GetById(studyProgramId).Result;
        var studentToEnroll = _studentRepository.GetById(studentId).Result;
        studyProgramToEnroll?.Students.Add(studentToEnroll!);
        _studyProgramRepository.Update(studyProgramToEnroll);
    }
    [HttpDelete("{studyProgramId}")]
    public void Delete([FromRoute] Guid studyProgramId)
    {
        _studyProgramRepository.Delete(studyProgramId);
    }
}