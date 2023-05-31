import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { StudyRegistration } from '../domain/studyRegistration.entity';

@Injectable()
export class StudyRegistrationService {
  constructor(
    @InjectRepository(StudyRegistration)
    private studyRegistrationRepository: Repository<StudyRegistration>,
  ) {}

  async getAllStudyRegistrations(): Promise<StudyRegistration[]> {
    return this.studyRegistrationRepository.find();
  }

  async createStudyRegistration(
    studyRegistration: StudyRegistration,
  ): Promise<StudyRegistration> {
    return this.studyRegistrationRepository.save(studyRegistration);
  }
}
