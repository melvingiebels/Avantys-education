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


@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: "mssql",
      host: "localhost",
      port: 1433,
      database: "AvantysEducationGuidanceTalk",
      extra: {
        trustedConnection:true,
        enableArithAbort: true,
      },
      options:{
        trustServerCertificate : true,
      },
      entities: [Student,Teacher,Note,GuidanceTalk,Appointment],
      synchronize: true,
      logging: false
    }),
    TypeOrmModule.forFeature([Student,Teacher,Note,GuidanceTalk,Appointment])
  ],
  controllers: [AppController,GuidanceTalkController],
  providers: [AppService, GuidanceTalkService],
})
export class AppModule {}
