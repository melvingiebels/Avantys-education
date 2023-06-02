import { Inject, Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { StudyRegistration } from '../domain/studyRegistration.entity';
import { ClientProxy } from '@nestjs/microservices';
import { Student } from 'src/domain/student.entity';

@Injectable()
export class StudyRegistrationService {
  constructor(
    @Inject('STUDY_PROGRAM_SERVICE') private clientStudyProgram: ClientProxy,
    @Inject('TEST_SERVICE') private clientTest: ClientProxy,
    @Inject('GUIDANCE_SERVICE') private clientGuidance: ClientProxy,
    @InjectRepository(StudyRegistration)
    private studyRegistrationRepository: Repository<StudyRegistration>,
    @InjectRepository(Student)
    private studentRepository: Repository<Student>,
  ) {}

  async getAllStudyRegistrations(): Promise<StudyRegistration[]> {
    return this.studyRegistrationRepository.find();
  }

  async createStudyRegistration(
    studyRegistration: StudyRegistration,
  ): Promise<StudyRegistration> {
    return this.studyRegistrationRepository.save(studyRegistration);
  }

  async acceptEnrollment(studentId: number) {
    console.log(studentId);
    // Perform the acceptance logic here
    await this.studyRegistrationRepository.update(
      { studentId: studentId },
      {
        enrollmentStatus: true,
      },
    );

    const student = await this.studentRepository.findOne({
      where: { id: studentId },
    });

    console.log(student);

    // Then emit the events to other microservices
    this.clientStudyProgram.emit('EnrollmentAccepted', student);
    this.clientTest.emit('EnrollmentAccepted', student);
    this.clientGuidance.emit('EnrollmentAccepted', student);

    return 'Student Enrollment accepted';
  }

  async deleteStudyRegistration(studentId: number): Promise<void> {
    await this.studyRegistrationRepository.delete({ studentId: studentId });
  }
}
