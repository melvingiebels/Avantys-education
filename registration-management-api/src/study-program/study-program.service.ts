import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { StudyProgram } from '../domain/studyProgram.entity';
import { StudyRegistration } from 'src/domain/studyRegistration.entity';

@Injectable()
export class StudyProgramService {
  constructor(
    @InjectRepository(StudyProgram)
    private studyProgramRepository: Repository<StudyProgram>,
    @InjectRepository(StudyRegistration)
    private studyRegistrationRepository: Repository<StudyRegistration>,
  ) {}

  async getAllStudyPrograms(): Promise<StudyProgram[]> {
    return this.studyProgramRepository.find();
  }

  async createStudyProgram(studyProgram: StudyProgram): Promise<StudyProgram> {
    return this.studyProgramRepository.save(studyProgram);
  }

  async updateStudyProgram(
    studyProgramId: number,
    studyProgram: StudyProgram,
  ): Promise<any> {
    console.log(studyProgram);
    await this.studyProgramRepository.update(studyProgramId, studyProgram);
    return studyProgram;
  }

  async deleteStudyProgram(studyProgramId: number): Promise<any> {
    await this.studyProgramRepository.delete({ id: studyProgramId });
    return 'StudyProgram deleted';
  }
}
