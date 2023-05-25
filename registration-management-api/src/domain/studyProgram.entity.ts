import { Entity, Column, PrimaryGeneratedColumn, OneToMany } from 'typeorm';
import { StudyRegistration } from './studyRegistration.entity';

@Entity()
export class StudyProgram {
  @PrimaryGeneratedColumn()
  id: number;

  @OneToMany(
    () => StudyRegistration,
    (studyRegistration) => studyRegistration.studyProgram,
  )
  studyRegistrations: StudyRegistration[];

  @Column()
  programName: string;

  @Column()
  description: string;

  @Column()
  duration: string;

  @Column()
  admissionRequirements: string;

  constructor(
    programName: string,
    description: string,
    duration: string,
    admissionRequirements: string,
  ) {
    this.programName = programName;
    this.description = description;
    this.duration = duration;
    this.admissionRequirements = admissionRequirements;
  }
}
