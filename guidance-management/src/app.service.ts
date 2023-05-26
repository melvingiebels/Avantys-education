import { Injectable } from '@nestjs/common';
import { Repository } from 'typeorm';
import { Teacher } from './domain/teacher.model';
import { Student } from './domain/student.model';
import { InjectRepository } from '@nestjs/typeorm';

@Injectable()
export class AppService {
  
  constructor( @InjectRepository(Teacher) private teacherRepository: Repository<Teacher>,@InjectRepository(Student)private studentRepository:Repository<Student>){

  }
  getHello(): string {
    return 'Hello World!';
  }

  
  async createTeacher(teacher:Teacher):Promise<Teacher>{
    return this.teacherRepository.save(teacher);
  }

  async createStudent(student:Student):Promise<Student>{
    return this.studentRepository.save(student);
  }


}
