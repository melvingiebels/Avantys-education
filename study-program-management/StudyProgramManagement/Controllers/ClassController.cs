using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly IRepository<Class?> _classRepository;
    private readonly IRepository<Student?> _studentRepository;


    public ClassController(IRepository<Class?> classRepository, IRepository<Student?> studentRepository)
    {
        _classRepository = classRepository;
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Class?>> Get()
    {
        return await _classRepository.Get();
    }

    [HttpGet("{classId}")]
    public async Task<Class?> GetById(Guid classId)
    {
        return await _classRepository.GetById(classId);
    }

    [HttpPost]
    public void Create([FromBody] Class model)
    {
        _classRepository.Create(model);
    }

    [HttpPut("{classId}/{studentId}")]
    public void Update([FromRoute] Guid classId, [FromRoute] Guid studentId)
    {
        var classToEnroll = _classRepository.GetById(classId).Result;
        var studentToEnroll = _studentRepository.GetById(studentId).Result;
        classToEnroll?.Students.Add(studentToEnroll!);
        _classRepository.Update(classToEnroll);
    }

    [HttpDelete("{classId}")]
    public void Delete([FromRoute] Guid classId)
    {
        _classRepository.Delete(classId);
    }
}