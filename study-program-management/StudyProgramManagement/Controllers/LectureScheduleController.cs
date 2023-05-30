using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Repos;

namespace StudyProgramManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureScheduleController : ControllerBase
{
    private readonly LectureScheduleRepository? _lecturesScheduleRepository;
    private readonly IRepository<Lecture> _lectureRepository;

    public LectureScheduleController(IRepository<LecturesSchedule> lecturesScheduleRepository, IRepository<Lecture> lectureRepository)
    {
        _lecturesScheduleRepository = lecturesScheduleRepository as LectureScheduleRepository;
        _lectureRepository = lectureRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<LecturesSchedule?>> Get()
    {
        return await _lecturesScheduleRepository!.Get();
    }

    [HttpGet("Module/{moduleId}")]
    public async Task<List<LecturesSchedule?>> GetByModuleId(Guid moduleId)
    {
        return await _lecturesScheduleRepository!.GetByModuleId(moduleId);
    }
    [HttpGet("Lecture/{lectureId}")]
    public async Task<LecturesSchedule?> GetByLectureId(Guid lectureId)
    {
        return await _lecturesScheduleRepository!.GetByLectureId(lectureId);
    }
    
    [HttpGet("{lecturesScheduleId}")]
    public async Task<LecturesSchedule?> GetById(Guid lecturesScheduleId)
    {
        return await _lecturesScheduleRepository!.GetById(lecturesScheduleId);
    }
    
    [HttpPost("{lectureId}")]
    public void Create([FromRoute] Guid lectureId ,[FromBody] LecturesSchedule? model)
    {
        var lectureToSchedule = _lectureRepository.GetById(lectureId).Result;
        model.Lecture = lectureToSchedule!;
        _lecturesScheduleRepository!.Create(model);
    }

    [HttpPut]
    public void Update([FromBody] LecturesSchedule? model)
    {
        _lecturesScheduleRepository!.Update(model);
    }
    [HttpDelete("{lectureScheduleId}")]
    public void Delete([FromRoute] Guid lectureScheduleId)
    {
        _lecturesScheduleRepository!.Delete(lectureScheduleId);
    }
}