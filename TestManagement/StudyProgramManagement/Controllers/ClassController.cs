using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly IRepository<Class?> _repository;
    
    public ClassController(ClassRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Class?>> Get()
    {
        return await _repository.Get();
    }
    
    [HttpGet("{classId}")]
    public async Task<Class?> GetById(Guid classId)
    {
        return await _repository.GetById(classId);
    }
    
    [HttpPost]
    public void Create([FromBody] Class model)
    {
        _repository.Create(model);
    }
    
    [HttpPut]
    public void Update([FromBody] Class model)
    {
        _repository.Create(model);
    }
}