using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class StudentCollection: MongoCollection<Student>
 {
     public StudentCollection(IMongoDatabase mongoDb) : base(mongoDb)
     {
     }
 }