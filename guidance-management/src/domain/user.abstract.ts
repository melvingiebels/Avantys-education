import { Column, Entity, ManyToOne, OneToMany, PrimaryGeneratedColumn } from "typeorm";
import { Appointment } from "./appointment.model";
import { Note } from "./note.model";

export abstract class BaseUser {
    @PrimaryGeneratedColumn()
    id:number;
    @Column()
    name:string;
    @Column()
    email:string;
    @Column()
    phonenumber:number;

    constructor(name:string,email:string,phonenumber:number){
        this.name = name;
        this.email = email;
        this.phonenumber = phonenumber;
    }
}