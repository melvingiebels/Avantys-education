import { Entity, Column, PrimaryGeneratedColumn, ManyToOne } from 'typeorm';
import { Student } from './student.entity';
import { StudyProgram } from './studyProgram.entity';

@Entity()
export class StudyRegistration {
  @PrimaryGeneratedColumn()
  id: number;

  @ManyToOne(() => Student, (student) => student.studyRegistrations)
  student: Student;

  @ManyToOne(
    () => StudyProgram,
    (studyProgram) => studyProgram.studyRegistrations,
  )
  studyProgram: StudyProgram;

  @Column()
  registrationDate: Date;

  @Column()
  status: string;

  constructor(
    student: Student,
    studyProgram: StudyProgram,
    registrationDate: Date,
    status: string,
  ) {
    this.student = student;
    this.studyProgram = studyProgram;
    this.registrationDate = registrationDate;
    this.status = status;
  }
}
