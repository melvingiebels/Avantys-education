using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase
{
    private readonly IRepository<Module?> _repository;

    public ModuleController(IRepository<Module?> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Module?>> Get()
    {
        return await _repository.Get();
    }

    [HttpGet("{moduleId}")]
    public async Task<Module?> GetById(Guid moduleId)
    {
        return await _repository.GetById(moduleId);
    }

    [HttpPost]
    public void Create([FromBody] Module model)
    {
        _repository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] Module model)
    {
        _repository.Create(model);
    }
}