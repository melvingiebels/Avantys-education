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

    @OneToOne(() => Book,{nullable:true})
    @JoinColumn()
    book?:Book;

    @ManyToOne(() => SchoolModule)
    schoolModule:SchoolModule;

    constructor(title:string,description:string,schoolModule:SchoolModule){
        this.title = title;
        this.description = description;
        this.schoolModule = schoolModule
    }
}