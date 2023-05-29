import { StudentService } from './student.service'; // import the StudentsService
import { Student } from '../domain/student.entity'; // import the Student entity
import { Body, Controller, Get, Post } from '@nestjs/common';
import { EventPattern } from '@nestjs/microservices';

@Controller('student')
export class StudentController {
  constructor(private readonly studentService: StudentService) {} // inject the StudentService

  @Get()
  helloVietnam() {
    return 'hello vietnam';
  }

  @EventPattern('registration_accepted')
  createInvoicing(data: Record<string, unknown>) {
    console.log('Testing', data);
    const student = new Student(data);
    return this.studentService.createInvoicing(student);
  }
}
