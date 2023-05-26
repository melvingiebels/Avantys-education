import { Body, Controller, Get, Post } from '@nestjs/common';
import { AppService } from './app.service';
import { Teacher } from './domain/teacher.model';
import { Student } from './domain/student.model';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get()
  getHello(): string {
    return this.appService.getHello();
  }

  @Post('teacher')
  async createTeacher(@Body() teacher:Teacher): Promise<Teacher>{
    console.log("Testing");
    return this.appService.createTeacher(teacher);
  }

  @Post('student')
  async createStudent(@Body() student:Student): Promise<Student>{
    return this.appService.createStudent(student);

  }

}
