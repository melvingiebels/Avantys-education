import { Body, Controller, Get, Param, Post } from '@nestjs/common';
import { StudyRegistrationService } from './study-registration.service';
import { StudyRegistration } from '../domain/studyRegistration.entity';

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
}
