

import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable()

export class ApiService{

    private selectedActivity = new Subject<any>();
    activitySelected = this.selectedActivity.asObservable();

    constructor(private http: HttpClient){

    }

    getActivity(){
       return this.http.get('https://localhost:44335/api/activity');
    }

    postActivity(activity: any){
        this.http.post('https://localhost:44335/api/activity',activity).subscribe(res => {
            console.log(res);
        });
    }

    putActivity(activity: any){
        this.http.put(`https://localhost:44335/api/activity/${activity.activityId}`,activity).subscribe(res => {
            console.log(res);
        });

    }


    selectActivity(activity: any){
        
        this.selectedActivity.next(activity);


    }


}