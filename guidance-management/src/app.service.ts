import { Inject, Injectable } from '@nestjs/common';
import { Repository } from 'typeorm';
import { Teacher } from './domain/teacher.model';
import { Student } from './domain/student.model';
import { InjectRepository } from '@nestjs/typeorm';
import { ClientProxy, MessagePattern } from '@nestjs/microservices';
import { connect } from 'amqp-connection-manager';

@Injectable()
export class AppService {
  
  constructor( @InjectRepository(Teacher) private teacherRepository: Repository<Teacher>,
              @InjectRepository(Student)private studentRepository:Repository<Student>,
              ){
              this.testRabbitMQConnection();
  }

  getHello(): string {
    return 'Hello World!';
  }
  async createTeacher(teacher:Teacher):Promise<Teacher>{
    

    return this.teacherRepository.save(teacher);
  }

  async createStudent(student:Student):Promise<Student>{
    return this.studentRepository.save(student);
  }


  async testRabbitMQConnection(){
    try{
      const connection = await connect('amqp://localhost:5672');
      console.log("connection successful: ", connection);

      connection.close();
    } catch(error) {
      console.error("connection failed: ", error);
    }
  }



}
