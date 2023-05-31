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
    @InjectRepository(Student) private studentRepository: Repository<Student>, @InjectRepository(Invoice) private invoiceRepository: Repository<Invoice>
    ) { }
    
    async createStudent(student: Student): Promise<Student> {
      return this.studentRepository.save(student);
    }
    async calculateTotalBalance(studentId: number): Promise<Balance> {
      const balance = new Balance();
      
      balance.student = await this.studentRepository.findOneBy({
        id: studentId
      });
      
      const invoiceEvents = await this.invoiceRepository.findBy({ student: { id: balance.student.id } });
      
      balance.totalInvoiceAmount = 0;
      
      invoiceEvents.forEach((invoiceEvent) => {
        balance.totalInvoiceAmount += invoiceEvent.invoiceAmount;
      });
      
      return balance;
    }
    async setStudentAcceptance(studentId: number, acceptance: boolean) {
      const student = await this.studentRepository.findOneBy({
        id: studentId
      });

   
      student.authorizedPayments = acceptance;

      return this.studentRepository.save(student);
    }
  }
  