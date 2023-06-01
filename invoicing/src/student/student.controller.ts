import { StudentService } from './student.service'; // import the StudentsService
import { Student } from '../domain/student.entity'; // import the Student entity
import { Body, Controller, Param, Get, Post, Put, Inject } from '@nestjs/common';
import { ClientProxy, EventPattern } from '@nestjs/microservices';

@Controller('student')
export class StudentController {
  constructor(private readonly studentService: StudentService, @Inject('REGISTRATION_SERVICE') private client: ClientProxy) { } // inject the StudentService

  @Get('/:studentId')
  getStudentBalance(@Param('id') studentId: number) {
    return this.studentService.calculateTotalBalance(studentId);
  }

  @EventPattern('RegistrationAccepted')
  createStudent(data: Record<string, unknown>) {
    const student = new Student(data);
    return this.studentService.createStudent(student);
  }

  @Put('/:studentId')
  setStudentAcceptance(@Param('id') studentId: number, @Param() acceptance: number) {
    let boolToSend = false;
    // if false, send an event to registrationmanagement
    if (acceptance == 0) {
      this.client.emit('StudentPaymentDeclined', studentId);
    } else{
      boolToSend = true;
      this.client.emit('StudentPaymentAccepted', studentId)
    }

    return this.studentService.setStudentAcceptance(studentId, boolToSend)
  }

}
