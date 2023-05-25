import { Module } from '@nestjs/common';
import { ClientsModule, Transport } from '@nestjs/microservices';
import { StudentController } from './student/student.controller';
import { StudentService } from './student/student.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Student } from './domain/student.entity';
import { Teacher } from './domain/teacher.entity';
import { StudyRegistration } from './domain/studyRegistration.entity';
import { StudyProgram } from './domain/studyProgram.entity';
import { Appointment } from './domain/appointment.enity';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'mssql',
      host: 'sqlserver',
      port: 1433,
      database: 'AvantysEducationRegistration',
      username: 'sa',
      password: 'MelvinIsEenBot34',
      options: {
        trustServerCertificate: true,
      },
      entities: [
        Student,
        Teacher,
        StudyRegistration,
        StudyProgram,
        Appointment,
      ],
      synchronize: true,
      logging: false,
    }),
    TypeOrmModule.forFeature([Student]),
    ClientsModule.register([
      {
        name: 'STUDENT_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: ['amqp://admin:password@rabbitmq:5672'],
          queue: 'student-messages',
          queueOptions: {
            durable: false,
          },
        },
      },
    ]),
  ],
  controllers: [StudentController],
  providers: [StudentService],
})
export class AppModule {}
