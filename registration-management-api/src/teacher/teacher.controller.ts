import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Post,
  Put,
} from '@nestjs/common';
import { TeacherService } from './teacher.service'; // import the TeacherService
import { Teacher } from '../domain/teacher.entity'; // import the Teacher entity
import { EventPattern } from '@nestjs/microservices';

@Controller('teacher')
export class TeacherController {
  constructor(private readonly teacherService: TeacherService) {} // inject the TeacherService

  @EventPattern('TeacherCreated')
  createTeacher(data: Record<string, unknown>) {
    console.log('Received from study program management', data);
    const teacher = new Teacher(data);
    return this.teacherService.createTeacher(teacher);
  }

  @EventPattern('TeacherUpdated')
  updateTeacher(data: Record<string, unknown>) {
    console.log('Received from study program management', data);
    const teacher = new Teacher(data);
    return this.teacherService.updateTeacher(teacher.id, teacher);
  }

  @EventPattern('TeacherDeleted')
  deleteTeacher(data: Record<string, unknown>) {
    console.log('Received from study program management', data);
    const teacher = new Teacher(data);
    return this.teacherService.deleteTeacher(teacher.id);
  }

  @Post()
  newTeacher(@Body() teacherDto: Teacher) {
    const teacher = new Teacher({ ...teacherDto });
    return this.teacherService.createTeacher(teacher);
  }

  @Get()
  getTeachers(): Promise<Teacher[]> {
    return this.teacherService.getAllTeachers();
  }

  @Put(':teacherId')
  updateStudyProgram(
    @Param('teacherId') teacherId: number,
    @Body() teacherDto: Teacher,
  ): Promise<Teacher> {
    const teacher = new Teacher({ ...teacherDto });
    return this.teacherService.updateTeacher(teacherId, teacher);
  }

  @Delete(':teacherId')
  deleteStudyProgram(@Param('teacherId') teacherId: number): Promise<Teacher> {
    return this.teacherService.deleteTeacher(teacherId);
  }
}
