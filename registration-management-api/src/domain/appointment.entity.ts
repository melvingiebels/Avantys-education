import {
  Entity,
  Column,
  PrimaryGeneratedColumn,
  ManyToOne,
  OneToOne,
} from 'typeorm';
import { Student } from './student.entity';
import { Teacher } from './teacher.entity';

@Entity()
export class Appointment {
  @PrimaryGeneratedColumn()
  id: number;

  @ManyToOne(() => Teacher, (teacher) => teacher.appointments)
  teacher: Teacher;

  @ManyToOne(() => Student, (student) => student.appointments)
  student: Student;

  @Column()
  date: Date;

  @Column()
  time: string;

  @Column()
  location: string;

  @Column()
  studentId: number;

  @Column()
  teacherId: number;

  constructor(appointmentDto: Partial<Appointment>) {
    Object.assign(this, appointmentDto);
  }
}
