import { Inject, Injectable } from '@nestjs/common';
import { Repository } from 'typeorm';
import { Student } from '../domain/student.entity'; // import the Student entity
import { InjectRepository } from '@nestjs/typeorm';
import { ClientProxy, MessagePattern } from '@nestjs/microservices';
import { connect } from 'amqp-connection-manager';

@Injectable()
export class StudentService {
  constructor(
    @InjectRepository(Student) private studentRepository: Repository<Student>,
  ) {}

  getHello(): string {
    return 'Hello World!';
  }

  async createInvoicing(student: Student): Promise<Student> {
    return this.studentRepository.save(student);
  }
}
