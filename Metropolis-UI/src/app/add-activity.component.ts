import { Component } from '@angular/core';

@Component({
    selector:'addactivity',
    templateUrl:'./add-activity.component.html'
})

export class AddActivityComponent{
    
    addActivity(activityName: string){

        console.log(activityName);
    }

}
