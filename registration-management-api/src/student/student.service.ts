import { Inject, Injectable } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

@Injectable()
export class StudentService {
  constructor(@Inject('STUDENT_SERVICE') private client: ClientProxy) {}

  async createStudent(name: string): Promise<any> {
    return this.client.emit('StudentCreated', { name });
  }

  async acceptRegistration(studentId: string) {
    // Perform the acceptance logic here

    // Then emit the event
    this.client.emit('registration_accepted', { studentId });
  }
}
