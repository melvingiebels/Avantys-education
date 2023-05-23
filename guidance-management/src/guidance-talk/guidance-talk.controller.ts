import { Controller, Get } from '@nestjs/common';

@Controller('example')
export class GuidanceTalkController {
  @Get()
  public getData(): string {
    return 'This is some data from the controller.';
  }
}