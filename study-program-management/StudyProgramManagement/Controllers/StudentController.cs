using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IRepository<Student?> _repository;

    public StudentController(IRepository<Student?> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Student?>> Get()
    {
        return await _repository.Get();
    }

    [HttpGet("{studentId}")]
    public async Task<Student?> GetById(Guid studentId)
    {
        return await _repository.GetById(studentId);
    }

    [HttpPost]
    public void Create([FromBody] Student model)
    {
        _repository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] Student model)
    {
        _repository.Update(model);
    }
    
    [HttpDelete("{studentId}")]
    public void Delete([FromRoute] Guid studentId)
    {
        _repository.Delete(studentId);
    }
}