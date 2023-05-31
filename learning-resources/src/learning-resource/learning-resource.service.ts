import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { StudyMaterialDto } from 'src/domain/DTO/study-material.dto';
import { Resource } from 'src/domain/resource.model';
import { SchoolModule } from 'src/domain/schoolmodule.model';
import { SchoolModuleDto } from 'src/domain/DTO/schoolmodule.dto';
import { StudyMaterial } from 'src/domain/study-material.model';
import { Repository} from 'typeorm'
import { ResourceDto } from 'src/domain/DTO/resource.dto';
import { GoogleBooksService } from 'src/google-books/google-books.service';

@Injectable()
export class LearningResourceService {
    constructor(@InjectRepository(StudyMaterial) private studyMaterialRepository: Repository<StudyMaterial>,
                @InjectRepository(Resource) private resourceRepostitory: Repository<Resource>,
                @InjectRepository(SchoolModule) private schoolModuleRepostitory: Repository<SchoolModule>,
                private readonly GoogleBookService:GoogleBooksService
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

    public async updateStudy(studyMaterialDto:StudyMaterialDto):Promise<StudyMaterial>{
        console.log("Updating a study!!")
        let study = await this.studyMaterialRepository.findOne({where:{StudyId:studyMaterialDto.studyId}})
        study.title = studyMaterialDto.title;
        return await this.studyMaterialRepository.save(study);
    }
    public async deleteStudy(studyMaterialDto:StudyMaterialDto){
        console.log("Deleting a study!!")
        await this.studyMaterialRepository.delete(studyMaterialDto.studyId);
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

    public async updateModule(schoolModuleDto:SchoolModuleDto):Promise<SchoolModule>{
        console.log("Updating a Module")
        let schoolModule = await this.schoolModuleRepostitory.findOne({where:{id:schoolModuleDto.id},relations:['studyMaterial']})        
        schoolModule.title = schoolModuleDto.title;
        return await this.schoolModuleRepostitory.save(schoolModule);
    }
    public async deleteModule(schoolModuleDto:SchoolModuleDto){
        console.log("Deleting a Module")
        await this.schoolModuleRepostitory.delete(schoolModuleDto.id);
    }

    public async createResource(resourceDto:ResourceDto){
        console.log("Creating Resources")
        console.log(resourceDto)
        
        try{
            let schoolModule = await this.schoolModuleRepostitory.findOne({where:{id:resourceDto.schoolModuleId}})
            let resource = new Resource(resourceDto.title,resourceDto.description,schoolModule);
            
            if(resourceDto.url){
                console.log("Adding URL")
                resource.url = resourceDto.url
            }
            
            if(resourceDto.bookname){
                console.log("Finding Book from Title")
                let book = await this.GoogleBookService.getGoogleBookFromTitle(resourceDto.bookname);
                console.log("====================RETURNING BOOK=====================")
                console.log(book);
                if(book.id != null){
                    resource.book = book;
                }
            }
            console.log("Before resource save")
            console.log(resource);
            
            return await this.resourceRepostitory.save(resource);
        }catch(e){
            console.log("Error")
            console.log(e)
        }

    }

}
