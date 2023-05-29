import { Entity, Column, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class Invoice {
  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  name: string;

  constructor(invoiceDto: Partial<Invoice>) {
    Object.assign(this, invoiceDto);
  }
}
