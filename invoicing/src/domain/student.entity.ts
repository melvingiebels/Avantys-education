import { Entity, Column, PrimaryGeneratedColumn, OneToMany } from 'typeorm';
import { Invoice } from './invoice.entity';

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

  @Column({default:false})
  authorizedPayments: boolean;

  @OneToMany(() => Invoice, (invoice) => invoice.student)
  invoices: Invoice[]

  constructor(studentDto: Partial<Student>) {
    Object.assign(this, studentDto);
  }
}
