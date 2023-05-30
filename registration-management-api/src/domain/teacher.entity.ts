import { Entity, Column, PrimaryGeneratedColumn, OneToMany } from 'typeorm';
import { Appointment } from './appointment.entity';

@Entity()
export class Teacher {
  @PrimaryGeneratedColumn()
  id: number;

  @OneToMany(() => Appointment, (appointment) => appointment.teacher)
  appointments: Appointment[];

  @Column()
  name: string;

  @Column()
  email: string;

  @Column()
  phone: string;

  constructor(studentDto: Partial<Teacher>) {
    Object.assign(this, studentDto);
  }
}
