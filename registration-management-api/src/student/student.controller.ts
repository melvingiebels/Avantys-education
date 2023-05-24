import {
  Body,
  Controller,
  Param,
  Post,
  UsePipes,
  ValidationPipe,
} from '@nestjs/common';
import { EventPattern } from '@nestjs/microservices';
import { StudentService } from './student.service'; // import the StudentsService
import { Student } from './student.entity'; // import the Student entity

@Controller('student')
export class StudentController {
  constructor(private readonly studentService: StudentService) {} // inject the StudentsService
  // ...

  @EventPattern('student_applied')
  async handleStudentApplied(data: Record<string, unknown>) {
    // Handle the event here
    console.log(data);
  }

  // @Post()
  // // @UsePipes(new ValidationPipe({ transform: true }))
  // newStudent(@Body() name: string) {
  //   const student = new Student(name);
  //   return this.studentService.createStudent(student);
  // }

  @Post()
  newStudent(@Body() studentDto: { name: string }) {
    const student = new Student(studentDto.name);
    return this.studentService.createStudent(student);
  }


  @Post('accept/:studentId')
  async acceptRegistration(@Param('studentId') studentId: string) {
    await this.studentService.acceptRegistration(studentId);
  }

  // ...
}
