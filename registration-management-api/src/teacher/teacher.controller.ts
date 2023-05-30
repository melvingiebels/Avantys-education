import { Body, Controller, Get, Post } from '@nestjs/common';
import { TeacherService } from './teacher.service'; // import the TeacherService
import { Teacher } from '../domain/teacher.entity'; // import the Teacher entity

@Controller('teacher')
export class TeacherController {
  constructor(private readonly teacherService: TeacherService) {} // inject the TeacherService

  @Get()
  getTeachers(): Promise<Teacher[]> {
    return this.teacherService.getAllTeachers();
  }

  @Post()
  newTeacher(@Body() teacherDto: Teacher) {
    const teacher = new Teacher({ ...teacherDto });
    return this.teacherService.createTeacher(teacher);
  }
}
