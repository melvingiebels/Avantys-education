import { Injectable } from '@nestjs/common';
import { Appointment } from 'src/domain/appointment.model';
import { Note } from 'src/domain/note.model';
import { Student } from 'src/domain/student.model';
import { Teacher } from 'src/domain/teacher.model';
import { IUser } from 'src/domain/user.interface';

@Injectable()
export class GuidanceTalkService {

    scheduleGuidanceTalkAppointment(title:string,description:string, teacher:Teacher,student:Student,startTime:Date,endTime:Date):Appointment{
        //TODO Get teacher,student from db
        const attendees:IUser[] = [teacher,student];
        let appointment = new Appointment(1,title,description,attendees,startTime,endTime);
        //TODO Send faux email to student teacher,
        //TODO create GuidanceTalk in database


        return appointment;
    }

    finishGuidanceTalk(guidanceTalkId:string,user:IUser,title:string,description:string){
        //TODO get guidance talk from database
        let notes = new Note(1,user,title,description);
        //TODO add notes to guidance talk.

    }

    getPreviousGuidanceTalkNotes(guidanceTalkId:string):string{
        //TODO get guidance talk fromDatabase

        //TODO send back notes

        return "generic notes";
    }

}
