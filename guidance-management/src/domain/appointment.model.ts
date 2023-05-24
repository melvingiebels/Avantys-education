import { Column, Entity, ManyToOne, OneToMany, OneToOne, PrimaryGeneratedColumn } from "typeorm";
import { BaseUser } from "./user.abstract";
import { Teacher } from "./teacher.model";
import { Student } from "./student.model";
import { GuidanceTalk } from "./guidanceTalk.model";

@Entity()
export class Appointment {
    @PrimaryGeneratedColumn()
    id:number;
    
    @Column()
    title:string;
    
    @Column()
    description:string;
    
    @ManyToOne(() => Teacher)
    teacher: Teacher;
  
    @ManyToOne(() => Student)
    student: Student;
    
    @Column()
    startTime:Date;

    @Column()
    endTime:Date;

    
    constructor(title:string,description:string,teacher:Teacher,student:Student,startTime:Date,endTime:Date){
        this.title = title;
        this.description = description;
        this.teacher = teacher;
        this.student = student;
        this.startTime = startTime;
        this.endTime = endTime
    }
}