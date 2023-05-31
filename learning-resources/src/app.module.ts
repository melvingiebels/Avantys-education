import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { LearningResourceService } from './learning-resource/learning-resource.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Resource } from './domain/resource.model';
import { SchoolModule } from './domain/schoolmodule.model';
import { StudyMaterial } from './domain/study-material.model';
import { ClientsModule, Transport } from '@nestjs/microservices';
import { LearningResourceController } from './learning-resource/learning-resource.controller';
import { GoogleBooksService } from './google-books/google-books.service';
import { HttpModule } from '@nestjs/axios';
import { Book } from './domain/book.model';

@Module({
  imports: [    
    HttpModule,
    TypeOrmModule.forRoot({
      type: "mssql",
      host: "sqlserver",
      port: 1433,
      database: "AvantysEducationLearningResource",
      username: "sa",
      password: "MelvinIsEenBot34",
      options: {
        trustServerCertificate: true
      },
      entities: [Resource,SchoolModule,StudyMaterial,Book],
      synchronize: true,
      logging: false
    }),
    TypeOrmModule.forFeature([Resource,SchoolModule,StudyMaterial,Book]),
  ],
  controllers: [AppController,LearningResourceController],
  providers: [AppService, LearningResourceService, GoogleBooksService],
})
export class AppModule {}
