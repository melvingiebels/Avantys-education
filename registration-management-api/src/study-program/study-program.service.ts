import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { StudyProgram } from '../domain/studyProgram.entity';

@Injectable()
export class StudyProgramService {
  constructor(
    @InjectRepository(StudyProgram)
    private studyProgramRepository: Repository<StudyProgram>,
  ) {}

  async getAllStudyPrograms(): Promise<StudyProgram[]> {
    return this.studyProgramRepository.find();
  }

  async createStudyProgram(studyProgram: StudyProgram): Promise<StudyProgram> {
    return this.studyProgramRepository.save(studyProgram);
  }
}
