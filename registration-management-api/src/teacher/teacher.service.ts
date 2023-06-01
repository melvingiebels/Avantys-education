import { Injectable } from '@nestjs/common';
import { Repository } from 'typeorm';
import { InjectRepository } from '@nestjs/typeorm';
import { Teacher } from '../domain/teacher.entity';

@Injectable()
export class TeacherService {
  constructor(
    @InjectRepository(Teacher)
    private teacherRepository: Repository<Teacher>,
  ) {}

  async getAllTeachers(): Promise<Teacher[]> {
    return this.teacherRepository.find();
  }

  async createTeacher(teacher: Teacher): Promise<any> {
    await this.teacherRepository.save(teacher);
    return teacher;
  }

  async updateTeacher(teacherId: number, teacher: Teacher): Promise<any> {
    await this.teacherRepository.update(teacherId, teacher);
    return teacher;
  }

  async deleteTeacher(teacherId: number): Promise<any> {
    await this.teacherRepository.delete({ id: teacherId });
    return 'Teacher deleted';
  }
}
