import { Body, Controller, Param, Post } from '@nestjs/common';
import { EventPattern } from '@nestjs/microservices';
import { StudentService } from './student.service'; // import the StudentsService

@Controller('student')
export class StudentController {
  constructor(private readonly studentService: StudentService) {} // inject the StudentsService
  // ...

  @EventPattern('student_applied')
  async handleStudentApplied(data: Record<string, unknown>) {
    // Handle the event here
    console.log(data);
  }

  @Post()
  newStudent(@Body() name: string) {
    return this.studentService.createStudent(name);
  }

  @Post('accept/:studentId')
  async acceptRegistration(@Param('studentId') studentId: string) {
    await this.studentService.acceptRegistration(studentId);
  }

  // ...
}
