import { Inject, Injectable } from '@nestjs/common';
import { Repository } from 'typeorm';
import { Student } from '../domain/student.entity'; // import the Student entity
import { InjectRepository } from '@nestjs/typeorm';
import { ClientProxy, MessagePattern } from '@nestjs/microservices';
import { connect } from 'amqp-connection-manager';
import { Invoice } from 'src/domain/invoice.entity';
import { Balance } from 'src/domain/balance';

@Injectable()
export class StudentService {
  constructor(
    @Inject('REGISTRATION_SERVICE') private client: ClientProxy,
    @InjectRepository(Student) private studentRepository: Repository<Student>,
    @InjectRepository(Invoice) private invoiceRepository: Repository<Invoice>,
  ) {}

  async createStudent(student: Student): Promise<Student> {
    return this.studentRepository.save(student);
  }
  async calculateTotalBalance(studentId: number): Promise<Balance> {
    const balance = new Balance();

    balance.student = await this.studentRepository.findOneBy({
      id: studentId,
    });

    const invoiceEvents = await this.invoiceRepository.findBy({
      student: { id: balance.student.id },
    });

    balance.totalInvoiceAmount = 0;

    invoiceEvents.forEach((invoiceEvent) => {
      balance.totalInvoiceAmount += invoiceEvent.invoiceAmount;
    });

    return balance;
  }
  async setStudentAcceptance(studentId: number, acceptance: boolean) {
    const student = await this.studentRepository.findOneBy({
      id: studentId,
    });

    console.log(student);

    // Todo - remove student.id from the student object
    student.authorizedPayments = acceptance;

    // if false, send an event to registrationmanagement
    if (!acceptance) {
      this.client.emit('StudentPaymentDeclined', studentId);
    } else {
      this.client.emit('StudentPaymentAccepted', studentId);
    }

    delete student.id;
    console.log(student);
    return await this.studentRepository.update(studentId, student);
  }
}

// Console logs:
// Acceptance is:  { acceptance: true }

// Student {

//   id: 6,

//   name: 'Luuk Doe',

//   email: 'johnydoe@example.com',

//   address: '123 Main St',

//   dateOfBirth: 1990-01-01T00:00:00.000Z,

//   authorizedPayments: false

// }

// Student {

//   id: 6,

//   name: 'Luuk Doe',

//   email: 'johnydoe@example.com',

//   address: '123 Main St',

//   dateOfBirth: 1990-01-01T00:00:00.000Z,

//   authorizedPayments: { acceptance: true }

// }
