import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
 
@Injectable()

export class ApiService{

    constructor(private http: HttpClient){

    }
    postActivity(activity){
        this.http.post('',activity).subscribe(res => {
            console.log(res);
        })

    }


}