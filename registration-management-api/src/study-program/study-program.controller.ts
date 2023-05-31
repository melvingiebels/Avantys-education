import { Body, Controller, Get, Post } from '@nestjs/common';
import { StudyProgramService } from './study-program.service';
import { StudyProgram } from '../domain/studyProgram.entity';

@Controller('study-program')
export class StudyProgramController {
  constructor(private readonly studyProgramService: StudyProgramService) {}

  @Get()
  getStudyPrograms(): Promise<StudyProgram[]> {
    return this.studyProgramService.getAllStudyPrograms();
  }

  @Post()
  createStudyProgram(
    @Body() studyProgramDto: StudyProgram,
  ): Promise<StudyProgram> {
    const studyProgram = new StudyProgram({ ...studyProgramDto });
    return this.studyProgramService.createStudyProgram(studyProgram);
  }
}
