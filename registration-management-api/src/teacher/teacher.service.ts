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

  async createTeacher(teacher: Teacher): Promise<any> {
    await this.teacherRepository.save(teacher);
    return teacher;
  }
}
