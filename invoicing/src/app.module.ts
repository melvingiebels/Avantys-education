import { Module } from '@nestjs/common';
import { StudentController } from './student/student.controller';
import { StudentService } from './student/student.service';
import { InvoiceController } from './invoice/invoice.controller';
import { InvoiceService } from './invoice/invoice.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Student } from './domain/student.entity';
import { Invoice } from './domain/invoice.entity';
import { ClientsModule, Transport } from '@nestjs/microservices';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'mssql',
      host: 'sqlserver',
      port: 1433,
      database: 'AvantysEducationInvoicing',
      username: 'sa',
      password: 'MelvinIsEenBot34',
      options: {
        trustServerCertificate: true,
      },
      entities: [Student, Invoice],
      synchronize: true,
      logging: false,
    }),
    TypeOrmModule.forFeature([Student, Invoice]),
    ClientsModule.register([
      {
        name: 'INVOICING_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: ['amqp://admin:password@rabbitmq:5672'],
          queue: 'INVOICING_QUEUE',
          queueOptions: {
            durable: false,
          },
        },
      },
    ]),
  ],
  controllers: [StudentController, InvoiceController],
  providers: [StudentService, InvoiceService],
})
export class AppModule {}
