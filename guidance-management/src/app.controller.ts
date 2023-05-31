import { Body, Controller, Get, Post } from '@nestjs/common';
import { AppService } from './app.service';
import { Teacher } from './domain/teacher.model';
import { Student } from './domain/student.model';
import { MessagePattern,MessageHandler, EventPattern, Transport } from '@nestjs/microservices';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @EventPattern('EnrollmentAccepted')
  createStudent(student: Student){
    console.log("Creating",student);
    return this.appService.createStudent(student);
  }


  @EventPattern('TeacherCreated')
  createTeacher(teacher: Teacher){
    console.log("Creating",teacher);
    this.appService.createTeacher(teacher);
  }

  @EventPattern('TeacherUpdated')
  updateTeacher(teacher: Teacher){
    console.log("Updating",teacher);
    this.appService.createTeacher(teacher);
  }

  @EventPattern('TeacherDeleted')
  deleteTeacher(teacher:Teacher){
    console.log('deleting',teacher)
    this.appService.deleteTeacher(teacher);
  }

}
