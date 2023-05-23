import { Column, PrimaryGeneratedColumn } from "typeorm";
import { IUser } from "./user.interface";

export class Teacher implements IUser {
    @PrimaryGeneratedColumn()
    id: string;
    
    @Column()
    name: string;
    
    @Column()
    email: string;

    @Column()
    phonenumber: number;

    constructor(id:string,name:string,email:string,phonenumber:number){
        this.id = id;
        this.name = name;
        this.email = email;
        this.phonenumber = phonenumber;
    }
}