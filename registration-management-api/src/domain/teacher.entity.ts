import {
  Entity,
  Column,
  PrimaryGeneratedColumn,
  OneToMany,
  ManyToOne,
} from 'typeorm';
import { Appointment } from './appointment.entity';
import { StudyProgram } from './studyProgram.entity';
import { StudyRegistration } from './studyRegistration.entity';

@Entity()
export class Teacher {
  @PrimaryGeneratedColumn()
  id: number;

  @OneToMany(() => Appointment, (appointment) => appointment.teacher)
  appointments: Appointment[];

  @ManyToOne(() => StudyProgram, (studyProgram) => studyProgram.teachers, {
    onDelete: 'SET NULL',
  })
  studyProgram: StudyProgram;

  @OneToMany(
    () => StudyRegistration,
    (studyRegistration) => studyRegistration.teacher,
  )
  studyRegistrations: StudyRegistration[];

  @Column()
  name: string;

  @Column()
  email: string;

  @Column()
  phone: string;

  @Column({
    nullable: true,
  })
  studyProgramId: number;

  constructor(studentDto: Partial<Teacher>) {
    Object.assign(this, studentDto);
  }
}
