import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { StudentsModule } from './students/students.module';
import { RabbitMQService } from './rabbitmq/rabbitmq.service';

@Module({
  imports: [StudentsModule],
  controllers: [AppController],
  providers: [AppService, RabbitMQService],
})
export class AppModule {}
