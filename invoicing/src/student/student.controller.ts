import { StudentService } from './student.service'; // import the StudentsService
import { Student } from '../domain/student.entity'; // import the Student entity
import {
  Body,
  Controller,
  Param,
  Get,
  Post,
  Put,
  Inject,
} from '@nestjs/common';
import { ClientProxy, EventPattern } from '@nestjs/microservices';

@Controller('student')
export class StudentController {
  constructor(
    private readonly studentService: StudentService,
    @Inject('REGISTRATION_SERVICE') private client: ClientProxy,
  ) {} // inject the StudentService

  @Get('/:studentId')
  getStudentBalance(@Param('studentId') studentId: number) {
    return this.studentService.calculateTotalBalance(studentId);
  }

  @EventPattern('RegistrationAccepted')
  createStudent(data: Record<string, unknown>) {
    console.log('RegistrationAccepted event received');
    console.log(data);
    const student = new Student(data);
    return this.studentService.createStudent(student);
  }

  @Put(':studentId')
  setStudentAcceptance(
    @Param('studentId') studentId: number,
    @Body('acceptance') acceptance: boolean,
  ) {
    console.log('Acceptance is: ', acceptance);
    return this.studentService.setStudentAcceptance(studentId, acceptance);
  }
}
