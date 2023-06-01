import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Post,
  Put,
} from '@nestjs/common';
import { StudyProgramService } from './study-program.service';
import { StudyProgram } from '../domain/studyProgram.entity';
import { EventPattern } from '@nestjs/microservices';

@Controller('study-program')
export class StudyProgramController {
  constructor(private readonly studyProgramService: StudyProgramService) {}

  @EventPattern('StudyProgramCreated')
  createTeacher(data: Record<string, unknown>) {
    console.log('Received from study program management', data);
    const studyProgram = new StudyProgram(data);
    return this.studyProgramService.createStudyProgram(studyProgram);
  }

  @EventPattern('StudyProgramUpdated')
  updateTeacher(data: Record<string, unknown>) {
    console.log('Received from study program management', data);
    const studyProgram = new StudyProgram(data);
    return this.studyProgramService.updateStudyProgram(
      studyProgram.id,
      studyProgram,
    );
  }

  @EventPattern('StudyProgramDeleted')
  deleteTeacher(data: Record<string, unknown>) {
    console.log('Received from study program management', data);
    const studyProgram = new StudyProgram(data);
    return this.studyProgramService.deleteStudyProgram(studyProgram.id);
  }

  @Get()
  getStudyPrograms(): Promise<StudyProgram[]> {
    return this.studyProgramService.getAllStudyPrograms();
  }

  @Put(':studyProgramId')
  updateStudyProgram(
    @Param('studyProgramId') studyProgramId: number,
    @Body() studyProgramDto: StudyProgram,
  ): Promise<StudyProgram> {
    const studyProgram = new StudyProgram({ ...studyProgramDto });
    return this.studyProgramService.updateStudyProgram(
      studyProgramId,
      studyProgram,
    );
  }

  @Delete(':studyProgramId')
  deleteStudyProgram(
    @Param('studyProgramId') studyProgramId: number,
  ): Promise<StudyProgram> {
    return this.studyProgramService.deleteStudyProgram(studyProgramId);
  }

  @Post()
  createStudyProgram(
    @Body() studyProgramDto: StudyProgram,
  ): Promise<StudyProgram> {
    const studyProgram = new StudyProgram({ ...studyProgramDto });
    return this.studyProgramService.createStudyProgram(studyProgram);
  }
}
