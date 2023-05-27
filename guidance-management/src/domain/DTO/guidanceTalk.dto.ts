import { Note } from "../note.model";

export class GuidanceTalkDto {
    readonly appointmentId: number; 
    readonly note: Note;
  }