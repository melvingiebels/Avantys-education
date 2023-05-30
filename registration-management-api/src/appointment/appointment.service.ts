import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { Appointment } from '../domain/appointment.entity';
import { Student } from 'src/domain/student.entity';

@Injectable()
export class AppointmentService {
  constructor(
    @InjectRepository(Appointment)
    private appointmentRepository: Repository<Appointment>,
    @InjectRepository(Student)
    private studentRepository: Repository<Student>,
  ) {}

  async getAllAppointments(): Promise<Appointment[]> {
    return this.appointmentRepository.find();
  }

  async createAppointment(appointment: Appointment): Promise<Appointment> {
    const student = await this.studentRepository.findOne({
      where: { id: appointment.studentId },
    });
    appointment.student = student;

    return this.appointmentRepository.save(appointment);
  }
}
