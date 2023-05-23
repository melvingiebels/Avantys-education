import { Column, Entity, PrimaryGeneratedColumn } from "typeorm";
import { IUser } from "./user.interface";

@Entity()
export class Appointment {
    @PrimaryGeneratedColumn()
    id:number;
    
    @Column()
    title:string;
    
    @Column()
    description:string;
    
    @Column()
    attendees:IUser[];
    
    @Column()
    startTime:Date;

    @Column()
    endTime:Date;

    
    constructor(id:number,title:string,description:string,attendees:IUser[],startTime:Date,endTime:Date){
        this.id = id;
        this.title = title;
        this.description = description;
        this.attendees = attendees;
        this.startTime = startTime;
        this.endTime = endTime
    }
}