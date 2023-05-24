import { Column, Entity, PrimaryGeneratedColumn } from "typeorm";
import { BaseUser } from "./user.abstract";

@Entity()
export class Teacher extends BaseUser {

    constructor(name:string,email:string,phonenumber:number){
        super(name,email,phonenumber)
    }
}