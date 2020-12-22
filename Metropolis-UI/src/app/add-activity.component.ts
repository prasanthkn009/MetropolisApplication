import { ApiService } from './api.service';
import { Component } from '@angular/core';


@Component({
    selector:'addactivity',
    templateUrl:'./add-activity.component.html'
})

export class AddActivityComponent{

    activity: any={}
    
    constructor(public api: ApiService){}

    ngOnInit(){
        this.api.activitySelected.subscribe(activity => this.activity =activity);
    }
    
    post(activity: any){

        this.api.postActivity(activity);
    }

}
