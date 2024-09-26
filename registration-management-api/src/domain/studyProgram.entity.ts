import {
  Entity,
  Column,
  PrimaryGeneratedColumn,
  OneToMany,
  ManyToOne,
} from 'typeorm';
import { StudyRegistration } from './studyRegistration.entity';
import { Teacher } from './teacher.entity';

@Entity()
export class StudyProgram {
  @PrimaryGeneratedColumn()
  id: number;

  @OneToMany(
    () => StudyRegistration,
    (studyRegistration) => studyRegistration.studyProgram,
  )
  studyRegistrations: StudyRegistration[];

  @OneToMany(() => Teacher, (teacher) => teacher.studyProgram)
  teachers: Teacher[];

  @Column()
  programName: string;

  @Column()
  description: string;

  @Column()
  duration: string;

  @Column()
  admissionRequirements: string;

  constructor(studyProgramDto: Partial<StudyProgram>) {
    Object.assign(this, studyProgramDto);
  }
}
