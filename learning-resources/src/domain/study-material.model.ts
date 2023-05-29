
import { Column, Entity, ManyToOne, OneToMany, PrimaryGeneratedColumn, PrimaryColumn } from "typeorm";
import { SchoolModule } from "./schoolmodule.model";

@Entity()
export class StudyMaterial {
    @PrimaryColumn()
    StudyId:number;
    @Column()
    title:string;
    @OneToMany(() => SchoolModule,schoolModule => schoolModule.studyMaterial)
    modules:SchoolModule[];

    
    constructor(id:number,title:string){
        this.StudyId = id;
        this.title = title;
    }

    public addModule(schoolModule:SchoolModule){
        this.modules.push(schoolModule);
    }
}