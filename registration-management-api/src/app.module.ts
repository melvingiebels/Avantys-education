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
    TypeOrmModule.forFeature([Student, Teacher, Appointment]),
    ClientsModule.register([
      {
        name: 'RegistrationService',
        transport: Transport.RMQ,
        options: {
          urls: [process.env.RABBITMQ_URL],
          queue: 'RegistrationQueue',
          queueOptions: {
            durable: false,
          },
        },
      },
      {
        name: 'AcceptanceService',
        transport: Transport.RMQ,
        options: {
          urls: [process.env.RABBITMQ_URL],
          queue: 'AcceptanceQueue',
          queueOptions: {
            durable: false,
          },
        },
      },
    ]),
  ],
  controllers: [StudentController, TeacherController, AppointmentController],
  providers: [StudentService, TeacherService, AppointmentService],
})
export class AppModule {}
