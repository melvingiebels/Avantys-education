using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class StudentCollection: MongoCollection<StudentSchema>
 {
     public StudentCollection(IMongoDatabase mongoDb) : base(mongoDb)
     {
     }
 }