import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { AppointmentDto } from 'src/domain/DTO/appointment.dto';
import { Appointment } from 'src/domain/appointment.model';
import { GuidanceTalk } from 'src/domain/guidanceTalk.model';
import { Note } from 'src/domain/note.model';
import { Student } from 'src/domain/student.model';
import { Teacher } from 'src/domain/teacher.model';
import { BaseUser } from 'src/domain/user.abstract';
import { Repository } from 'typeorm';

@Injectable()
export class GuidanceTalkService {

    constructor(@InjectRepository(Note) private noteRepository: Repository<Note>,
                @InjectRepository(GuidanceTalk)private guidanceTalkRepository:Repository<GuidanceTalk>,
                @InjectRepository(Appointment)private appointmentRepository:Repository<Appointment>,
                @InjectRepository(Teacher)private teacherRepository:Repository<Teacher>,
                @InjectRepository(Student)private studentRepository:Repository<Student>){

    }

    async scheduleGuidanceTalkAppointment(appointment:AppointmentDto):Promise<Appointment>{
        //TODO Get teacher,student from db
        console.log(appointment);
        let student = await this.studentRepository.findOne({where:{id:appointment.student}});
        let teacher = await this.teacherRepository.findOne({where:{id:appointment.teacher}});
        console.log("Found: ");
        let startTime = new Date(appointment.startTime);
        let endTime = new Date(appointment.endTime);
        let appoint = new Appointment(appointment.title,appointment.description,teacher,student,startTime,endTime);

        console.log(typeof(appoint.startTime),typeof(appoint.endTime))
        console.log(appoint)
        //TODO Send faux email to student teacher,
        return await this.appointmentRepository.save(appoint);
    }

    async finishGuidanceTalk(appointmentId:number,note:Note):Promise<GuidanceTalk>{

        let appointment = await this.appointmentRepository.findOne({where:{id:appointmentId},relations:['teacher','student']})
        await this.noteRepository.save(note);
        
        let guidanceTalk = new GuidanceTalk(appointment,note)
        console.log('=========================');
        console.log(guidanceTalk);
        console.log(typeof(guidanceTalk));
        return await this.guidanceTalkRepository.save(guidanceTalk);
    }

    async getPreviousGuidanceTalkNotes(guidanceTalkId:number):Promise<GuidanceTalk>{
        let guidanceTalk = this.guidanceTalkRepository.findOne({where:{
            id:guidanceTalkId
        }});


        return await guidanceTalk;
    }

}
