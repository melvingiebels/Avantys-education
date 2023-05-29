using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureController:ControllerBase
{
    private readonly IRepository<Lecture?> _lectureRepository;
    private readonly IRepository<Module?> _moduleRepository;

    public LectureController(IRepository<Lecture?> lectureRepository, IRepository<Module?> moduleRepository)
    {
        _lectureRepository = lectureRepository;
        _moduleRepository = moduleRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Lecture?>> Get()
    {
        return await _lectureRepository.Get();
    }

    [HttpGet("{lectureId}")]
    public async Task<Lecture?> GetById(Guid lectureId)
    {
        return await _lectureRepository.GetById(lectureId);
    }

    [HttpPost("{moduleId}")]
    public void Create([FromRoute] Guid moduleId, [FromBody] Lecture model)
    {
        model.Module = _moduleRepository.GetById(moduleId).Result!;
        _lectureRepository.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] Lecture model)
    {
        _lectureRepository.Update(model);
    }
    [HttpDelete("{lectureId}")]
    public void Delete([FromRoute] Guid lectureId)
    {
        _lectureRepository.Delete(lectureId);
    }
}