import {
  Entity,
  Column,
  PrimaryGeneratedColumn,
  OneToOne,
  ManyToOne,
} from 'typeorm';
import { Student } from './student.entity';

@Entity()
export class Invoice {
  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  eventDescription: string;

  @Column()
  invoiceAmount: number;

  @ManyToOne(() => Student, (student) => student.invoices)
  student: Student;

  constructor(invoiceDto: Partial<Invoice>) {
    Object.assign(this, invoiceDto);
  }
}
