import { Component } from '@angular/core';
import { FullstackService } from '../service/fullstack.service';
import { College } from '../models/College';

@Component({
  selector: 'app-college',
  templateUrl: './college.component.html',
  styleUrls: ['./college.component.css']
})
export class CollegeComponent {
  collegeArray:Array<any>=[];
  constructor(private collegeService:FullstackService){
    this.getCollege();
  }
clg:College={
  collegeName:"",
  collegeRank:0,
  collegeType:""
}
  getCollege(){
    this.collegeService.getCollegeService().subscribe((data)=>{
      console.log(data);
      this.collegeArray=data;
    })
  }
  num!:number;
  editclg(i:number){
    this.num=i;
    return this.num;
  }

  updateCollege(){
    this.collegeService.updateCollegeService(this.num,this.clg).subscribe((data)=>{
      alert("Are You Ok to Update ? :"+"\nCollege Name: "+this.clg.collegeName+"\nCollege Rank: "+this.clg.collegeRank+"\nCollege Type : "+this.clg.collegeType);
      console.log(data);
      this.getCollege();
      this.clg.collegeName="";
      this.clg.collegeRank=0;
      this.clg.collegeType="";
    })
  }

  removeCollege(i:number){
    this.collegeService.deleteCollegeService(i).subscribe((data)=>{
      alert("Are You to OK to Delete ?")
      console.log(data);
      this.getCollege();
    })
  }

}
