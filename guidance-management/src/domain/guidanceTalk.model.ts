import { Column, Entity, PrimaryGeneratedColumn } from "typeorm";
import { Appointment } from "./appointment.model";
import { Note } from "./note.model";

@Entity()
export class GuidanceTalk {
    @PrimaryGeneratedColumn()
    id:number;
    
    @Column()
    appointment:Appointment;
    
    @Column()
    notes:Note;

    constructor(id:number,appointment:Appointment,notes:Note){
        this.id = id;
        this.appointment = appointment;
        this.notes = notes;
    }
}