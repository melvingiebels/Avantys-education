import { NestFactory } from '@nestjs/core';
import { MicroserviceOptions, Transport } from '@nestjs/microservices';
import { AppModule } from './app.module';
import { RabbitMQService } from './rabbitmq/rabbitmq.service';

async function bootstrap() {
  const app = await NestFactory.createMicroservice<MicroserviceOptions>(
    AppModule,
    {
      transport: Transport.RMQ,
      options: {
        urls: ['amqp://localhost:5672'],
        queue: 'potential-student',
        queueOptions: {
          durable: true,
        },
      },
    },
  );
  const rabbitMQService = app.get<RabbitMQService>(RabbitMQService);
  await rabbitMQService.init(); // Initialize the RabbitMQ service

  await app.listenAsync();
}

bootstrap();
