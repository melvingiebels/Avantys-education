import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { Appointment } from '../domain/appointment.entity';
import { Student } from 'src/domain/student.entity';
import { Teacher } from 'src/domain/teacher.entity';

@Injectable()
export class AppointmentService {
  constructor(
    @InjectRepository(Appointment)
    private appointmentRepository: Repository<Appointment>,
    @InjectRepository(Student)
    private studentRepository: Repository<Student>,
    @InjectRepository(Teacher)
    private teacherRepository: Repository<Teacher>,
  ) {}

  async getAllAppointments(): Promise<Appointment[]> {
    return this.appointmentRepository.find();
  }

  async createAppointment(appointment: Appointment): Promise<Appointment> {
    const student = await this.studentRepository.findOne({
      where: { id: appointment.studentId },
    });
    const teacher = await this.teacherRepository.findOne({
      where: { id: appointment.teacherId },
    });

    if (student && teacher) {
      const savedAppointment = await this.appointmentRepository.save(
        appointment,
      );

      return savedAppointment;
    } else {
      return null;
    }
  }
}
