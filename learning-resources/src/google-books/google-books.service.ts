import { HttpService } from '@nestjs/axios';
import { Repository,Like} from 'typeorm'
import { Inject, Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import axios, { AxiosError } from 'axios';
import { catchError } from 'rxjs';
import { Book } from 'src/domain/book.model';
import { ClientProxy } from '@nestjs/microservices';

@Injectable()
export class GoogleBooksService {
    constructor(private readonly httpService: HttpService,
        @InjectRepository(Book) private bookRepostitory: Repository<Book>,
        ) {}
    private url:string =  process.env.GOOGLE_BOOKS_API_URL;
    private apiKey:string = process.env.GOOGLE_BOOKS_API_KEY;


    public async getGoogleBookFromTitle(title:string):Promise<Book>{
        let b = await this.bookRepostitory.findOne({where:{title:Like("%" + title + "%")}})
        if(b){
            console.log("returning book")
            return b;
        }
        let stringBuilder = this.url + "?key=" + this.apiKey + "&q=" + title;
        
        console.log("Builder ")
        console.log(stringBuilder)
        let jsonBook = (await axios.get(stringBuilder)).data
    
        try {
            let book:Book;
            for(const item of jsonBook.items){
                let desc = item.volumeInfo.description.substring(0, 250)
                let exists = await this.bookRepostitory.findOne({where:{id:item.id}});
                if(exists){
                    return exists
                }

                book = {
                    id:item.id,
                    title:item.volumeInfo.title,
                    description:desc,
                    apiLink:item.selfLink,
                    authors:item.volumeInfo.authors[0],
                    publisher:item.volumeInfo.publisher
                }
                if(item.accessInfo.epub.acsTokenLink){
                    book.epubLink = item.accessInfo.epub.acsTokenLink;
                }
                if(item.accessInfo.pdf.acsTokenLink){
                    book.pdfLink = item.accessInfo.pdf.acsTokenLink;
                }
                let requiredKeys = ['id','title','description','apiLink','authors','publisher']
                let checkAllKeys = requiredKeys.every((i) => book.hasOwnProperty(i));
                
                if(checkAllKeys){
                    console.log("Final Book:")
                    console.log(book);
                    return await this.bookRepostitory.save(book);
                }
                console.log("Not found")
            }
            console.log("Not Found definite edition")
            return book;

        }catch(e){
            console.log(e);
            return new Book();
        }
        
    }

}
