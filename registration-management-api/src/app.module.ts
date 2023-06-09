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
import { TeacherService } from './teacher/teacher.service';
import { TeacherController } from './teacher/teacher.controller';

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
    TypeOrmModule.forFeature([Student, Teacher]),
    ClientsModule.register([
      {
        name: 'REGISTRATION_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: ['amqp://admin:password@rabbitmq:5672'],
          queue: 'REGISTRATION_QUEUE',
          queueOptions: {
            durable: false,
          },
        },
      },
    ]),
  ],
  controllers: [StudentController, TeacherController],
  providers: [StudentService, TeacherService],
})
export class AppModule {}
