import { Body, Controller, Get, Post } from '@nestjs/common';
import { AppService } from './app.service';
import { Teacher } from './domain/teacher.model';
import { Student } from './domain/student.model';
import { MessagePattern,MessageHandler, EventPattern, Transport } from '@nestjs/microservices';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get()
  getHello(): string {
    return this.appService.getHello();
  }

  //@Post('student')
  async createStudent(@Body() student:Student): Promise<Student>{
    return this.appService.createStudent(student);

  }

}
