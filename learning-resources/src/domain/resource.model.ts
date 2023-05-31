import { Column, Entity, ManyToOne, OneToOne, PrimaryGeneratedColumn, JoinColumn} from "typeorm";
import { SchoolModule } from "./schoolmodule.model";
import { Book } from "./book.model";


@Entity()
export class Resource {
    @PrimaryGeneratedColumn()
    id:number;

    @Column()
    title:string;

    @Column()
    description:string;

    @Column({nullable:true})
    url?:string;

    @OneToOne(() => Book,{nullable:true,onDelete:'SET NULL'})
    @JoinColumn()
    book?:Book;

    @ManyToOne(() => SchoolModule,{nullable:true,onDelete:"CASCADE",onUpdate:'CASCADE'})
    schoolModule:SchoolModule;

    constructor(title:string,description:string,schoolModule:SchoolModule){
        this.title = title;
        this.description = description;
        this.schoolModule = schoolModule
    }
}