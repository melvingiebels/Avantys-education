import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { StudyMaterialDto } from 'src/domain/DTO/study-material.dto';
import { Resource } from 'src/domain/resource.model';
import { SchoolModule } from 'src/domain/schoolmodule.model';
import { SchoolModuleDto } from 'src/domain/DTO/schoolmodule.dto';
import { StudyMaterial } from 'src/domain/study-material.model';
import { Repository} from 'typeorm'
import { ResourceDto } from 'src/domain/DTO/resource.dto';

@Injectable()
export class LearningResourceService {
    constructor(@InjectRepository(StudyMaterial) private studyMaterialRepository: Repository<StudyMaterial>,
                @InjectRepository(Resource) private resourceRepostitory: Repository<Resource>,
                @InjectRepository(SchoolModule) private schoolModuleRepostitory: Repository<SchoolModule>,
                ){}


    public async getStudy(id:number):Promise<StudyMaterial>{
        console.log("Getting everythin from: " + id)
        console.log(id);
        console.log(typeof(id));
        
        return await this.studyMaterialRepository.findOne({
            where:{StudyId:id},
            relations:['modules','modules.resources']
        })
    }

    public async createStudy(studyMaterialDto:StudyMaterialDto):Promise<StudyMaterial>{
        console.log("Creating a study!!")
        let studyMaterial = new StudyMaterial(studyMaterialDto.studyId,studyMaterialDto.title)
        return await this.studyMaterialRepository.save(studyMaterial);
    }

    public async getResourcesFromModule(id:number):Promise<SchoolModule>{
        console.log("Getting every resource from module: " + id)
        return await this.schoolModuleRepostitory.findOne({
            where:{id:id},
            relations:['resources']
        })
    }

    public async createModule(schoolModuleDto:SchoolModuleDto):Promise<SchoolModule>{
        console.log("Creating a Module")
        let studyMaterial = await this.studyMaterialRepository.findOne({where:{StudyId:schoolModuleDto.studyMaterialId}})
        let schoolModule = new SchoolModule(schoolModuleDto.id,schoolModuleDto.title,studyMaterial);
        return await this.schoolModuleRepostitory.save(schoolModule);
    }


    public async createResource(resourceDto:ResourceDto){
        console.log("Creating Resources")
        let schoolModule = await this.schoolModuleRepostitory.findOne({where:{id:resourceDto.schoolModuleId}})
        let resource = new Resource(resourceDto.title,resourceDto.description,resourceDto.url,schoolModule);
        return await this.resourceRepostitory.save(resource);
    }

}
