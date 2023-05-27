import { Entity, Column, PrimaryGeneratedColumn, ManyToOne } from 'typeorm';
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

  constructor(
    teacher: Teacher,
    student: Student,
    date: Date,
    time: string,
    location: string,
  ) {
    this.teacher = teacher;
    this.student = student;
    this.date = date;
    this.time = time;
    this.location = location;
  }
}
