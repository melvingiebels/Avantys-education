import { Body, Controller, Get, Param, Post } from '@nestjs/common';
import { InvoiceService } from './invoice.service';
import { Student } from 'src/domain/student.entity';
import { InvoiceDto } from 'src/domain/invoice.dto';
import { StudentService } from 'src/student/student.service';

@Controller('invoice')
export class InvoiceController {
    constructor(private readonly invoiceService: InvoiceService, private readonly studentService: StudentService) { } // inject the StudentService

    @Get('/:studentId')
    getInvoiceByStudent(@Param('id') studentId: number) {
        console.log('Student', studentId);

        let result = this.invoiceService.getInvoice(studentId);

        return result;
    }

    @Post('/:studentId')
    createInvoice(@Param('id') studentId: number, @Body() invoice: InvoiceDto) {
        return this.invoiceService.createInvoice(studentId, invoice);
    }

}
