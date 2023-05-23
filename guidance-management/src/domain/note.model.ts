import { Column, Entity, PrimaryGeneratedColumn } from "typeorm";
import { IUser } from "./user.interface";

@Entity()
export class Note{
    @PrimaryGeneratedColumn()
    id:number;
    @Column()
    user:IUser;
    @Column()
    title:string;
    @Column()
    description:string;

    constructor(id:number,user:IUser,title:string,description:string){
        this.id = id;
        this.user = user;
        this.title = title;
        this.description = description;
    }

}