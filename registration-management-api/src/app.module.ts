import { Module } from '@nestjs/common';
import { ClientsModule, Transport } from '@nestjs/microservices';
import { StudentController } from './student/student.controller';
import { StudentService } from './student/student.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Student } from './domain/student.entity';
import { Teacher } from './domain/teacher.entity';
import { StudyRegistration } from './domain/studyRegistration.entity';
import { StudyProgram } from './domain/studyProgram.entity';
import { Appointment } from './domain/appointment.entity';
import { TeacherService } from './teacher/teacher.service';
import { TeacherController } from './teacher/teacher.controller';
import { config } from 'dotenv';
import { AppointmentService } from './appointment/appointment.service';
import { AppointmentController } from './appointment/appointment.controller';
import { StudyProgramController } from './study-program/study-program.controller';
import { StudyProgramService } from './study-program/study-program.service';
import { StudyRegistrationService } from './study-registration/study-registration.service';
import { StudyRegistrationController } from './study-registration/study-registration.controller';

// Specify the path to your .env file
config();
@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'mssql',
      host: 'sqlserver',
      port: 1433,
      database: process.env.MYSQL_DATABASE,
      username: process.env.MYSQL_USERNAME,
      password: process.env.MYSQL_PASSWORD,
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
    TypeOrmModule.forFeature([
      Student,
      Teacher,
      Appointment,
      StudyProgram,
      StudyRegistration,
    ]),
    ClientsModule.register([
      {
        name: 'INVOICING_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: [process.env.RABBITMQ_URL],
          queue: 'INVOICING_QUEUE',
          queueOptions: {
            durable: false,
          },
        },
      },
      {
        name: 'STUDY_PROGRAM_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: [process.env.RABBITMQ_URL],
          queue: 'STUDY_PROGRAM_QUEUE',
          queueOptions: {
            durable: false,
          },
        },
      },
      {
        name: 'TEST_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: [process.env.RABBITMQ_URL],
          queue: 'TEST_QUEUE',
          queueOptions: {
            durable: false,
          },
        },
      },
      {
        name: 'GUIDANCE_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: [process.env.RABBITMQ_URL],
          queue: 'GUIDANCE_QUEUE',
          queueOptions: {
            durable: false,
          },
        },
      },
    ]),
  ],
  controllers: [
    StudentController,
    TeacherController,
    AppointmentController,
    StudyProgramController,
    StudyRegistrationController,
  ],
  providers: [
    StudentService,
    TeacherService,
    AppointmentService,
    StudyProgramService,
    StudyRegistrationService,
  ],
})
export class AppModule {}
