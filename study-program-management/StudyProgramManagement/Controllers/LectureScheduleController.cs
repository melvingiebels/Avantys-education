using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureScheduleController : ControllerBase
{
    private readonly IRepository<LecturesSchedule?> _repository;

    public LectureScheduleController(IRepository<LecturesSchedule?> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<LecturesSchedule?>> Get()
    {
        return await _repository.Get();
    }

    [HttpGet("{moduleId}")]
    public async Task<LecturesSchedule?> GetById(Guid moduleId)
    {
        return await _repository.GetById(moduleId);
    }

    [HttpPost]
    public void Create([FromBody] LecturesSchedule model)
    {
        _repository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] LecturesSchedule model)
    {
        _repository.Create(model);
    }
}