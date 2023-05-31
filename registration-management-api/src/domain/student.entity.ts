import {
  Entity,
  Column,
  PrimaryGeneratedColumn,
  OneToMany,
  OneToOne,
} from 'typeorm';
import { StudyRegistration } from './studyRegistration.entity';
import { Appointment } from './appointment.entity';

@Entity()
export class Student {
  @PrimaryGeneratedColumn()
  id: number;

  @OneToMany(
    () => StudyRegistration,
    (studyRegistration) => studyRegistration.student,
  )
  studyRegistrations: StudyRegistration[];

  @OneToMany(() => Appointment, (appointment) => appointment.teacher)
  appointments: Appointment[];

  @Column()
  name: string;

  @Column()
  email: string;

  @Column()
  address: string;

  @Column()
  dateOfBirth: Date;

  @Column()
  accceptanceStatus: boolean;

  constructor(studentDto: Partial<Student>) {
    Object.assign(this, studentDto);
  }
}
