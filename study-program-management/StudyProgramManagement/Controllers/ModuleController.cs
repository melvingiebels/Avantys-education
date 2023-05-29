using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase
{
    private readonly IRepository<Module?> _moduleRepository;
    private readonly IRepository<Teacher?> _teacherRepository;
    private readonly IRepository<Lecture?> _lectureRepository;
    public ModuleController(IRepository<Module?> moduleRepository, IRepository<Teacher?> teacherRepository, IRepository<Lecture?> lectureRepository)
    {
        _moduleRepository = moduleRepository;
        _teacherRepository = teacherRepository;
        _lectureRepository = lectureRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Module?>> Get()
    {
        return await _moduleRepository.Get();
    }

    [HttpGet("{moduleId}")]
    public async Task<Module?> GetById(Guid moduleId)
    {
        return await _moduleRepository.GetById(moduleId);
    }

    [HttpPost]
    public void Create([FromBody] Module model)
    {
        _moduleRepository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] Module model)
    {
        _moduleRepository.Create(model);
    }
    
    [HttpPut("AddTeacher/{moduleId}/{teacherId}")]
    public void AddTeacherToModule([FromRoute] Guid moduleId, Guid teacherId)
    {
        var moduleToAttach = _moduleRepository.GetById(moduleId).Result;
        var teacherToBeAttached = _teacherRepository.GetById(teacherId).Result;
        moduleToAttach!.Teachers.Add(teacherToBeAttached!);
        _moduleRepository.Update(moduleToAttach);
    }
    
        
    [HttpPut("AddLecture/{moduleId}/{lectureId}")]
    public void AddLectureToModule([FromRoute] Guid moduleId, Guid lectureId)
    {
        var moduleToAttach = _moduleRepository.GetById(moduleId).Result;
        var lectureToBeAttached = _lectureRepository.GetById(lectureId).Result;
        moduleToAttach!.Lectures.Add(lectureToBeAttached!);
        _moduleRepository.Update(moduleToAttach);
    }
    
        
    [HttpDelete("{moduleId}")]
    public void Delete([FromRoute] Guid moduleId)
    {
        _moduleRepository.Delete(moduleId);
    }
}