import { Body, Controller, Get, Post } from '@nestjs/common';
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
}
