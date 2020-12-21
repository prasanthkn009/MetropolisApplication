

import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable()

export class ApiService{

    constructor(private http: HttpClient){

    }

    getActivity(){
       return this.http.get('https://localhost:44335/api/activity');
    }

    postActivity(activity: any){
        this.http.post('https://localhost:44335/api/activity',activity).subscribe(res => {
            console.log(res);
        })

    }


}