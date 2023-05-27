import { Inject, Injectable } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';
import { Repository } from 'typeorm';
import { InjectRepository } from '@nestjs/typeorm';
import { Student } from '../domain/student.entity';

@Injectable()
export class StudentService {
  constructor(
    @Inject('REGISTRATION_SERVICE') private client: ClientProxy,
    @InjectRepository(Student)
    private studentRepository: Repository<Student>,
  ) {}

  async createStudent(student: Student): Promise<any> {
    await this.studentRepository.save(student);
    return this.client.emit('StudentCreated', student);
  }

  async acceptRegistration(studentId: number) {
    // Perform the acceptance logic here
    await this.studentRepository.update(studentId, { accceptanceStatus: true });

    const updatedStudent = await this.studentRepository.findOne({
      where: { id: studentId },
    });

    // Then emit the event
    this.client.emit('registration_accepted', { updatedStudent });

    return updatedStudent;
  }
}
