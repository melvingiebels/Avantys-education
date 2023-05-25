import { Entity, Column, PrimaryGeneratedColumn, OneToMany } from 'typeorm';
import { Appointment } from './appointment.enity';

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

  constructor(name: string, email: string, phone: string) {
    this.name = name;
    this.email = email;
    this.phone = phone;
  }
}
