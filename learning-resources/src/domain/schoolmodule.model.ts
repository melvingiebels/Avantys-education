import { Column, Entity, ManyToOne, OneToOne, PrimaryColumn,OneToMany } from "typeorm";
import { Resource } from "./resource.model";
import { StudyMaterial } from "./study-material.model";

@Entity()
export class SchoolModule {
    @PrimaryColumn()
    id:number;
    
    @Column()
    title:string;

    @OneToMany(() => Resource, resource => resource.schoolModule)
    resources:Resource[];

    @ManyToOne(() => StudyMaterial, {onDelete:"CASCADE",onUpdate:'CASCADE'})
    studyMaterial:StudyMaterial;


    constructor(id:number,title:string,studyMaterial:StudyMaterial){
        this.id = id;
        this.title = title;
        this.studyMaterial = studyMaterial
    }

    public addResource(resource:Resource){
        this.resources.push(resource);
    }
}