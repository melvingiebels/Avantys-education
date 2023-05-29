import { Entity, Column, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class Student {
  @PrimaryGeneratedColumn()
  id: number;

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
