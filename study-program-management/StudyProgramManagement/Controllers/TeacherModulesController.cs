using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherModulesController : ControllerBase
{
    private readonly TeacherModulesRepository? _repository;

    public TeacherModulesController(IRepository<TeacherModules?> repository)
    {
        _repository = repository as TeacherModulesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<TeacherModules?>> Get()
    {
        return await _repository!.Get();
    }

    [HttpGet("{moduleId}")]
    public async Task<TeacherModules?> GetByModuleId(Guid moduleId)
    {
        return await _repository!.GetByModuleId(moduleId);
    }

    [HttpGet("{teacherId}")]
    public async Task<TeacherModules?> GetByTeacherId(Guid teacherId)
    {
        return await _repository!.GetByTeacherId(teacherId);
    }

    [HttpGet("{teacherModulesId}")]
    public async Task<TeacherModules?> GetById(Guid teacherModulesId)
    {
        return await _repository!.GetById(teacherModulesId);
    }

    [HttpPost]
    public void Create([FromBody] TeacherModules model)
    {
        _repository!.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] TeacherModules model)
    {
        _repository!.Create(model);
    }
}