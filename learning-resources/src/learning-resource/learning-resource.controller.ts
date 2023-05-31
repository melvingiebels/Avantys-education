import { Body, Controller, Get, Param, Post, Query } from '@nestjs/common';
import { LearningResourceService } from './learning-resource.service';
import { StudyMaterialDto } from 'src/domain/DTO/study-material.dto';
import { StudyMaterial } from 'src/domain/study-material.model';
import { SchoolModuleDto } from 'src/domain/DTO/schoolmodule.dto';
import { SchoolModule } from 'src/domain/schoolmodule.model';
import { Resource } from 'src/domain/resource.model';
import { ResourceDto } from 'src/domain/DTO/resource.dto';
import { EventPattern } from '@nestjs/microservices';

@Controller("LearningResource")
export class LearningResourceController {
  constructor(private readonly LearningResourceService:LearningResourceService) {}

  //CRUD FOR Study Program
  @Get("study/:id")
  public async GetStudy(@Param('id') id:number):Promise<StudyMaterial>{
    console.log(id);
    return await this.LearningResourceService.getStudy(id);
  }
  @EventPattern("StudyProgramCreated")
  public async createStudy(study:StudyMaterialDto){
    console.log("Creating Study Program")
    await this.LearningResourceService.createStudy(study);
  }
  @EventPattern("StudyProgramUpdated")
  public async updateStudy(study:StudyMaterialDto){
    console.log("Updating Study Program")
    await this.LearningResourceService.updateStudy(study);
  }
  @EventPattern("StudyProgramDeleted")
  public async deleteStudy(study:StudyMaterialDto){
    console.log("Deleting Study Program")
    await this.LearningResourceService.deleteStudy(study);
  }

  //CRUD FOR MODULE
  @Get("module/:id")
  public async GetModuleResources(@Param('id') id:number){
    console.log(id);
    return await this.LearningResourceService.getResourcesFromModule(id);
  }
  @EventPattern("ModuleCreated")
  public async createModule(@Body() module:SchoolModuleDto){
    console.log("Create module")
    return await this.LearningResourceService.createModule(module);
  }
  @EventPattern("ModuleUpdated")
  public async updateModule(@Body() module:SchoolModuleDto){
    console.log("Updated module")
    await this.LearningResourceService.updateModule(module);
  }
  @EventPattern("ModuleDeleted")
  public async deleteModule(@Body() module:SchoolModuleDto){
    console.log("Delete module")
    await this.LearningResourceService.deleteModule(module);
  }


  @Post("resource")
  public async createResource(@Body() resource:ResourceDto){
    console.log("Create Resource");
    return await this.LearningResourceService.createResource(resource);
  
  }

}
