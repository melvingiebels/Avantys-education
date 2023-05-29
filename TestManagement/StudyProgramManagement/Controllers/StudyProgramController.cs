using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class StudyProgramController : ControllerBase
{
    private readonly IRepository<StudyProgram?> _repository;

    public StudyProgramController(IRepository<StudyProgram?> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<StudyProgram?>> Get()
    {
        return await _repository.Get();
    }

    [HttpGet("{studyProgramId}")]
    public async Task<StudyProgram?> GetById(Guid studyProgramId)
    {
        return await _repository.GetById(studyProgramId);
    }

    [HttpPost]
    public void Create([FromBody] StudyProgram model)
    {
        _repository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] StudyProgram model)
    {
        _repository.Create(model);
    }
}