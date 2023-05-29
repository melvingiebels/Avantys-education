import { Body, Controller, Get, Param, Post, Query } from '@nestjs/common';
import { LearningResourceService } from './learning-resource.service';
import { StudyMaterialDto } from 'src/domain/DTO/study-material.dto';
import { StudyMaterial } from 'src/domain/study-material.model';
import { SchoolModuleDto } from 'src/domain/DTO/schoolmodule.dto';
import { SchoolModule } from 'src/domain/schoolmodule.model';
import { Resource } from 'src/domain/resource.model';
import { ResourceDto } from 'src/domain/DTO/resource.dto';

@Controller("LearningResource")
export class LearningResourceController {
  constructor(private readonly LearningResourceService:LearningResourceService) {}


  @Get("study/:id")
  public async GetStudy(@Param('id') id:number):Promise<StudyMaterial>{
    console.log(id);
    return await this.LearningResourceService.getStudy(id);
  }

  //Change this later to a rabbitmq message
  @Post("study")
  public async createStudy(@Body() studyMaterial:StudyMaterialDto):Promise<StudyMaterial>{
    console.log("Creating study")
    return await this.LearningResourceService.createStudy(studyMaterial);
  }

  @Get("module/:id")
  public async GetModuleResources(@Param('id') id:number){
    console.log(id);
    return await this.LearningResourceService.getResourcesFromModule(id);
  }
  
  //Change this later to a rabbitmq message
  @Post("module")
  public async createModule(@Body() module:SchoolModuleDto): Promise<SchoolModule> {
    console.log("Create module")
    return await this.LearningResourceService.createModule(module);
  }



  @Post("resource")
  public async createResource(@Body() resource:ResourceDto){
    console.log("Create Resource");
    return await this.LearningResourceService.createResource(resource);
  
  }

}
