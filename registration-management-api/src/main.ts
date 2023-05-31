import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { SwaggerModule, DocumentBuilder } from '@nestjs/swagger';
import { MicroserviceOptions, Transport } from '@nestjs/microservices';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);

  const config = new DocumentBuilder()
    .setTitle('Registration API')
    .setDescription('Potential Students can register here')
    .setVersion('1.0')
    .addTag('Registration')
    .build();
  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup('api', app, document);

  app.connectMicroservice<MicroserviceOptions>({
    transport: Transport.RMQ,
    options: {
      urls: ['amqp://admin:password@rabbitmq:5672'],
      queue: 'REGISTRATION_QUEUE',
      queueOptions: {
        durable: false,
      },
    },
  });
  await app.startAllMicroservices();

  await app.listen(3001);
}
bootstrap();
