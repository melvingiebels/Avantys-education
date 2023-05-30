import { Inject, Injectable } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';
import { Repository } from 'typeorm';
import { InjectRepository } from '@nestjs/typeorm';
import { Student } from '../domain/student.entity';

@Injectable()
export class StudentService {
  constructor(
    @Inject('RegistrationService') private client: ClientProxy,
    @InjectRepository(Student)
    private studentRepository: Repository<Student>,
  ) {}

  async getAllStudents(): Promise<Student[]> {
    return this.studentRepository.find();
  }

  async createStudent(student: Student): Promise<any> {
    await this.studentRepository.save(student);
    this.client.emit('StudentCreated', student);
    return student;
  }

  async acceptRegistration(studentId: number) {
    // Perform the acceptance logic here
    await this.studentRepository.update(studentId, { accceptanceStatus: true });

    const updatedStudent = await this.studentRepository.findOne({
      where: { id: studentId },
    });

    console.log(updatedStudent);
    // Then emit the event
    this.client.emit('RegistrationAccepted', updatedStudent);

    return updatedStudent;
  }
}
