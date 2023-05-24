import { Column, Entity, PrimaryGeneratedColumn } from "typeorm";
import { BaseUser } from "./user.abstract";

@Entity()
export class Student extends BaseUser {

    constructor(name:string,email:string,phonenumber:number){
        super(name,email,phonenumber)
    }
}