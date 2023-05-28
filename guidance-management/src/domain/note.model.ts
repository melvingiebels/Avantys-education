import { Column, Entity, ManyToOne, OneToOne, PrimaryGeneratedColumn } from "typeorm";
import { BaseUser } from "./user.abstract";
import { GuidanceTalk } from "./guidanceTalk.model";
import { Student } from "./student.model";
import { Teacher } from "./teacher.model";

@Entity()
export class Note{
    @PrimaryGeneratedColumn()
    id:number;
    @ManyToOne(() => Student)
    student:Student;
    @Column()
    title:string;
    @Column()
    description:string;


    constructor(student:Student,title:string,description:string){
        this.student = student;
        this.title = title;
        this.description = description;
    }

}