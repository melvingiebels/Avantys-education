import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { GuidanceTalkService } from './guidance-talk/guidance-talk.service';
import { GuidanceTalkController } from './guidance-talk/guidance-talk.controller';
import {TypeOrmModule} from '@nestjs/typeorm'
import { Student } from './domain/student.model';
import { Teacher } from './domain/teacher.model';
import { Note } from './domain/note.model';
import { GuidanceTalk } from './domain/guidanceTalk.model';
import { Appointment } from './domain/appointment.model';
import { BaseUser } from './domain/user.abstract';
import { ClientsModule, Transport } from '@nestjs/microservices';


@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: "mssql",
      host: "sqlserver",
      port: 1433,
      database: "AvantysEducationGuidanceTalk",
      username: "sa",
      password: "MelvinIsEenBot34",
      options: {
        trustServerCertificate: true
      },
      entities: [Student,Teacher,BaseUser,Note,GuidanceTalk,Appointment],
      synchronize: true,
      logging: false
    }),
    TypeOrmModule.forFeature([Student,Teacher,BaseUser,Note,GuidanceTalk,Appointment]),
    ClientsModule.register([
      {
        name: 'GUIDANCE_MANAGEMENT_SERVICE',
        transport: Transport.RMQ,
        options: {
          urls: ['amqp://admin:password@rabbitmq:5672'],
          queue: 'GUIDANCE_QUEUE',
          queueOptions: {
            durable: false,
          },
        },
      },
    ]),

  ],
  controllers: [AppController,GuidanceTalkController],
  providers: [AppService, GuidanceTalkService],
})
export class AppModule {}
