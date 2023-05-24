import { Injectable } from '@nestjs/common';
import { Appointment } from 'src/domain/appointment.model';
import { Note } from 'src/domain/note.model';
import { Student } from 'src/domain/student.model';
import { Teacher } from 'src/domain/teacher.model';
import { BaseUser } from 'src/domain/user.abstract';

@Injectable()
export class GuidanceTalkService {

    scheduleGuidanceTalkAppointment(title:string,description:string, teacher:Teacher,student:Student,startTime:Date,endTime:Date):Appointment{
        //TODO Get teacher,student from db
        let appointment = new Appointment(title,description,teacher,student,startTime,endTime);
        //TODO Send faux email to student teacher,
        //TODO create GuidanceTalk in database


        return appointment;
    }

    finishGuidanceTalk(guidanceTalkId:string,user:BaseUser,title:string,description:string){
        //TODO get guidance talk from database
        let notes = new Note(user,title,description);
        //TODO add notes to guidance talk.

    }

    getPreviousGuidanceTalkNotes(guidanceTalkId:string):string{
        //TODO get guidance talk fromDatabase

        //TODO send back notes

        return "generic notes";
    }

}
