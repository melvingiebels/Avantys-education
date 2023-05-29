import { Column, Entity, ManyToOne, OneToOne, PrimaryGeneratedColumn } from "typeorm";
import { SchoolModule } from "./schoolmodule.model";


@Entity()
export class Resource {
    @PrimaryGeneratedColumn()
    id:number;

    @Column()
    title:string;

    @Column()
    description:string;

    @Column()
    url:string;

    @ManyToOne(() => SchoolModule)
    schoolModule:SchoolModule;

    constructor(title:string,description:string,url:string,schoolModule:SchoolModule){
        this.title = title;
        this.description = description;
        this.url = url;
        this.schoolModule = schoolModule
    }
}