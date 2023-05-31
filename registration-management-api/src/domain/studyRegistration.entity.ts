import { Entity, Column, PrimaryGeneratedColumn, ManyToOne } from 'typeorm';
import { Student } from './student.entity';
import { Teacher } from './teacher.entity';
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

  @ManyToOne(() => Teacher, (teacher) => teacher.studyRegistrations)
  teacher: Teacher;

  @Column()
  registrationDate: Date;

  @Column()
  status: string;

  @Column({
    nullable: true,
  })
  studentId: number;

  @Column({
    nullable: true,
  })
  teacherId: number;

  @Column({
    nullable: true,
  })
  studyProgramId: number;

  constructor(studyReigstrationtDto: Partial<StudyRegistration>) {
    Object.assign(this, studyReigstrationtDto);
  }
}
