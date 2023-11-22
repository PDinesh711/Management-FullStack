import { Component } from '@angular/core';
import { FullstackService } from '../service/fullstack.service';
import { Student } from '../models/Student';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {

studentArray:Array<any>=[];
teacherArray:Array<any>=[];

student1:Student={
  StudentName:"",
  studentDepartment:"",
  studentEmail:"",
  studentAge:0,
  studentPhone:"",
  studentFees:0
}

constructor(private studentService:FullstackService){
  this.getStudent();
  this.getTeacher();
}

// student 
getStudent(){
  this.studentService.getStudentService().subscribe((data)=>{
    console.log(data);
    this.studentArray=data;
  })
}

//teacher 
getTeacher(){
  this.studentService.getTeacherService().subscribe((data)=>{
this.teacherArray=data;
  })
}

num!:number;
edit(i:number){
this.num=i;
console.log(this.num);
return this.num;
}

editStudent(){
this.studentService.updateStudent(this.num,this.student1).subscribe((data)=>{
  alert("Are you OK to Add :"+"\nStudent Name : "+this.student1.StudentName+"\nStudent Email : "+this.student1.studentEmail+"\nStudent Department : "+this.student1.studentDepartment+"\nStudent Age: "+this.student1.studentAge+"\nStudent Phone : "+this.student1.studentPhone+"\nStudent Fees: "+this.student1.studentFees);
  console.log(data);
  this.getStudent();
  this.student1.StudentName="";
  this.student1.studentDepartment="";
  this.student1.studentEmail="";
  this.student1.studentAge=0;
  this.student1.studentPhone="";
  this.student1.studentFees=0
})
}

removeStudent(i:number){
  this.studentService.removeStudentService(i).subscribe((data)=>{
    alert("Are You OK to Delete ?");
    console.log(data);
    this.getStudent();
  })
}

}
