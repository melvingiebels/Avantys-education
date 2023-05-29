using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly IRepository<Teacher?> _repository;

    public TeacherController(IRepository<Teacher?> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Teacher?>> Get()
    {
        return await _repository.Get();
    }

    [HttpGet("{teacherId}")]
    public async Task<Teacher?> GetById(Guid teacherId)
    {
        return await _repository.GetById(teacherId);
    }

    [HttpPost]
    public void Create([FromBody] Teacher model)
    {
        _repository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] Teacher model)
    {
        _repository.Update(model);
    }
}