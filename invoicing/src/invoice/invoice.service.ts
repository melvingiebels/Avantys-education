import { Inject, Injectable } from '@nestjs/common';
import { Repository } from 'typeorm';
import { Student } from '../domain/student.entity'; // import the Student entity
import { InjectRepository } from '@nestjs/typeorm';
import { ClientProxy, MessagePattern } from '@nestjs/microservices';
import { connect } from 'amqp-connection-manager';
import { Invoice } from 'src/domain/invoice.entity';
import { InvoiceDto } from 'src/domain/invoice.dto';

@Injectable()
export class InvoiceService {
    constructor(
        @InjectRepository(Invoice) private invoiceRepository: Repository<Invoice>, @InjectRepository(Student) private studentRepository: Repository<Student>
    ) { }

    async getInvoice(studentId: number): Promise<Invoice[]> {
        const student = await this.studentRepository.findOneBy({
            id: studentId
        })

        return await this.invoiceRepository.findBy({student});
    }
    async createInvoice(studentId: number, invoiceDto: InvoiceDto) {
        const invoice = new Invoice(invoiceDto);

        invoice.student = await this.studentRepository.findOneBy({
            id: studentId,
        });

        return await this.invoiceRepository.save(invoice);
    }
}
