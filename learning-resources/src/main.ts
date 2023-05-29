import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { MicroserviceOptions, Transport } from '@nestjs/microservices';
import { DocumentBuilder, SwaggerModule } from '@nestjs/swagger';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);

  app.connectMicroservice<MicroserviceOptions>({
    transport:Transport.RMQ,
    options:{
      urls: ['amqp://admin:password@rabbitmq:5672'],
      queue:'REGISTRATION_QUEUE',
      queueOptions:{
        durable:false
      }
    }
  })
  const config = new DocumentBuilder()
    .setTitle('Learning Resources')
    .setDescription('The learning resources service API endpoints')
    .setVersion('1.0')
    .addTag('learning')
    .addTag('resources')
    .build();
  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup('api', app, document);

  await app.startAllMicroservices();
  await app.listen(3002);
}
bootstrap();
