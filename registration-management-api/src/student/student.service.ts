import { Inject, Injectable } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';
import { Repository } from 'typeorm';
import { InjectRepository } from '@nestjs/typeorm';
import { Student } from './student.entity';

@Injectable()
export class StudentService {
  constructor(
    @Inject('STUDENT_SERVICE') private client: ClientProxy,
    @InjectRepository(Student)
    private studentRepository: Repository<Student>,
  ) {}

  async createStudent(student: Student): Promise<any> {
    await this.studentRepository.save(student);
    return this.client.emit('StudentCreated', student);
    // return this.client.emit('StudentCreated', { student });
  }

  async acceptRegistration(studentId: string) {
    // Perform the acceptance logic here

    // Then emit the event
    this.client.emit('registration_accepted', { studentId });
  }
}
