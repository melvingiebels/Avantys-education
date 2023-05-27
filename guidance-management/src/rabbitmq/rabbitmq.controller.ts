import { Controller,Get } from "@nestjs/common";
import { Ctx, MessagePattern, Payload, RmqContext } from "@nestjs/microservices";

@Controller()
export class RabbitmqController {
    constructor() {}

    @MessagePattern('notifications')
    getNotifications(@Payload() data:number[], @Ctx() context:RmqContext){
        const channel = context.getChannelRef();
        const originalMsg = context.getMessage();
        console.log(originalMsg);
        channel.ack(originalMsg);
    }
}