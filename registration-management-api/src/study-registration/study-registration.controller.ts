import { Body, Controller, Get, Param, Post } from '@nestjs/common';
import { StudyRegistrationService } from './study-registration.service';
import { StudyRegistration } from '../domain/studyRegistration.entity';
import { EventPattern } from '@nestjs/microservices';
import { Student } from 'src/domain/student.entity';

@Controller('study-registration')
export class StudyRegistrationController {
  constructor(
    private readonly studyRegistrationService: StudyRegistrationService,
  ) {}

  @Get()
  getStudyRegistrations(): Promise<StudyRegistration[]> {
    return this.studyRegistrationService.getAllStudyRegistrations();
  }

  @Post()
  createStudyRegistration(
    @Body() studyRegistrationDto: StudyRegistration,
  ): Promise<StudyRegistration> {
    const studyRegistration = new StudyRegistration({
      ...studyRegistrationDto,
    });
    return this.studyRegistrationService.createStudyRegistration(
      studyRegistration,
    );
  }

  @Post('enroll/:studentId')
  async acceptRegistration(@Param('studentId') studentId: number) {
    return this.studyRegistrationService.acceptEnrollment(studentId);
  }

  @EventPattern('StudentPaymentAccepted')
  acceptRegistrationWithPayment(data: Record<string, unknown>) {
    console.log('Received from invoice', data);
    const student = new Student(data);
    return this.studyRegistrationService.acceptEnrollment(student.id);
  }

  @EventPattern('StudentPaymentDeclined')
  deleteRegistration(data: Record<string, unknown>) {
    console.log('Received from invoice', data);
    const student = new Student(data);
    return this.studyRegistrationService.deleteStudyRegistration(student.id);
  }
}
