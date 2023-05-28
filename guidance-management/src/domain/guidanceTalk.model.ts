import { Column, Entity, ManyToOne, OneToOne, PrimaryGeneratedColumn } from "typeorm";
import { Appointment } from "./appointment.model";
import { Note } from "./note.model";

@Entity()
export class GuidanceTalk {
    @PrimaryGeneratedColumn()
    id:number;
    
    @ManyToOne(() => Appointment)
    appointment:Appointment;
    
    @ManyToOne(() => Note)
    note:Note;

    constructor(appointment:Appointment,note:Note){
        this.appointment = appointment;
        this.note = note;
    }
}