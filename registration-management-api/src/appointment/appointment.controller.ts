import { Body, Controller, Get, Post } from '@nestjs/common';
import { AppointmentService } from './appointment.service';
import { Appointment } from '../domain/appointment.entity';

@Controller('appointment')
export class AppointmentController {
  constructor(private readonly appointmentService: AppointmentService) {}

  @Get()
  getAppointments(): Promise<Appointment[]> {
    return this.appointmentService.getAllAppointments();
  }

  @Post()
  createAppointment(@Body() appointmentDto: Appointment): Promise<Appointment> {
    const appointment = new Appointment({ ...appointmentDto });
    return this.appointmentService.createAppointment(appointment);
  }
}
