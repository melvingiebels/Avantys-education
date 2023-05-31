import { Body, Controller, Get, Param, Post } from '@nestjs/common';
import { EventPattern } from '@nestjs/microservices';
import { StudentService } from './student.service'; // import the StudentsService
import { Student } from '../domain/student.entity'; // import the Student entity

@Controller('student')
export class StudentController {
  constructor(private readonly studentService: StudentService) {} // inject the StudentService

  @EventPattern('student_applied')
  async handleStudentApplied(data: Record<string, unknown>) {
    // Handle the event here
    console.log(data);
  }

  @Get()
  getStudents(): Promise<Student[]> {
    return this.studentService.getAllStudents();
  }

  @Post()
  async newStudent(@Body() studentDto: Student) {
    const student = new Student({ ...studentDto });
    return this.studentService.createStudent(student);
  }

  @Post('accept/:studentId')
  async acceptRegistration(@Param('studentId') studentId: number) {
    return this.studentService.acceptRegistration(studentId);
  }
}
