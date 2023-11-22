import { Component } from '@angular/core';
import { FullstackService } from '../service/fullstack.service';
import { Teacher } from '../models/Teacher';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent {
teacherArray:Array<any>=[];
constructor(private teacherService:FullstackService){
  this.getTeacher();
}
teacher1:Teacher={
teacherName:"",
teacherSubjet:"",
teacherSalary:0
}
num!:number;
edit(i:number){
  this.num=i;
  return this.num;
}
getTeacher(){
  this.teacherService.getTeacherService().subscribe((data)=>{
    console.log(data);
    this.teacherArray=data;
  })
}
updateTeacher(){
  this.teacherService.updateTeacherService(this.num,this.teacher1).subscribe((data)=>{
    alert("Are You OK to Update ? : "+"\nTeacher Name: "+this.teacher1.teacherName+"\nTeacher Subject : "+this.teacher1.teacherSubjet+"\nTeacher Salary : "+this.teacher1.teacherSalary);
    console.log(data);
    this.getTeacher();
   this.teacher1.teacherName="";
this.teacher1.teacherSubjet="";
this.teacher1.teacherSalary=0
  })
}
removeTeacher(i:number){
  this.teacherService.removeTeacherService(i).subscribe((data)=>{
    alert("Are You OK to Delete ?");
    console.log(data);
  })
}
}
