import { Module } from '@nestjs/common';
import { StudentsService } from './students.service';
import { RabbitMQService } from '../rabbitmq/rabbitmq.service';
import { StudentsController } from './students.controller';

@Module({
  providers: [StudentsService],
  controllers: [StudentsController],
})
export class StudentsModule {}
