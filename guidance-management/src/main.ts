import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { MicroserviceOptions, Transport } from '@nestjs/microservices';
import { DocumentBuilder, SwaggerModule } from '@nestjs/swagger';

async function bootstrap() {
  let app = await NestFactory.create(AppModule);
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
    .setTitle('Guidance Management')
    .setDescription('The Guidance Management service API endpoints')
    .setVersion('1.0')
    .addTag('Guidance')
    .build();
  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup('api', app, document);


  await app.startAllMicroservices();
  await app.listen(3000);
}
bootstrap();
