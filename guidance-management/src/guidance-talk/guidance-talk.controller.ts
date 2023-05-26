import { Body, Controller, Get, Param, Post, Query } from '@nestjs/common';
import { GuidanceTalkService } from './guidance-talk.service';
import { Appointment } from 'src/domain/appointment.model';
import { GuidanceTalkDto } from 'src/domain/DTO/guidanceTalk.dto';
import { GuidanceTalk } from 'src/domain/guidanceTalk.model';
import { AppointmentDto } from 'src/domain/DTO/appointment.dto';

@Controller('GuidanceTalk')
export class GuidanceTalkController {
  private GTService:GuidanceTalkService
  constructor(private readonly guidanceTalkService: GuidanceTalkService) {
    this.GTService = guidanceTalkService;

  }

  @Post('appointment')
  public async scheduleGuidanceTalkAppointment(@Body() appointment:AppointmentDto):Promise<Appointment>{
    console.log(appointment);
    return await this.GTService.scheduleGuidanceTalkAppointment(appointment);
  }

  @Post()
  public async finishGuidanceTalk(@Body() payload:GuidanceTalkDto ):Promise<GuidanceTalk>{
    let appointmentId = payload.appointmentId;  
    let note = payload.note;

    return await this.guidanceTalkService.finishGuidanceTalk(appointmentId,note);
  }

  @Get()
  public async getGuidanceTalk(@Param('id') id:number):Promise<GuidanceTalk>{
    console.log(id);
    return this.guidanceTalkService.getPreviousGuidanceTalkNotes(id)
  }

}