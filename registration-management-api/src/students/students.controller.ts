import { Controller, Get } from '@nestjs/common';

@Controller('students')
export class StudentsController {
  @Get()
  getStudents() {
    return 'All students';
  }
}
