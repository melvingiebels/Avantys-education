import { Column, Entity, ManyToOne, OneToOne, PrimaryColumn } from "typeorm";
import { SchoolModule } from "./schoolmodule.model";


@Entity()
export class Book {
    @PrimaryColumn()
    id:string;
    @Column()
    title:string;
    @Column({length:255})
    description:string;
    @Column()
    apiLink:string;
    @Column()
    authors:string;
    @Column()
    publisher:string;
    @Column({nullable:true})
    epubLink?:string = "unknown";
    @Column({nullable:true})
    pdfLink?:string = "unknown";

    constructor(){}


}