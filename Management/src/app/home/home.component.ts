import { Component } from '@angular/core';
import { College } from '../models/College';
import { FullstackService } from '../service/fullstack.service';
import { Student } from '../models/Student';
import { Teacher } from '../models/Teacher';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  teacherArray:Array<any>=[];
clg:College={
  collegeName:"",
  collegeRank:0,
  collegeType:""
}
student:Student={
  StudentName:"",
  studentDepartment:"",
  studentEmail:"",
  studentAge:0,
  studentPhone:"",
  studentFees:0
}
teacher:Teacher={
  teacherName:"",
  teacherSubjet:"",
  teacherSalary:0
}
constructor(private homeService:FullstackService,private router:Router){
  this.getTeacher();
}
//college
createCollege(){
  this.homeService.createCollegeService(this.clg).subscribe((data)=>{
    alert("Are you OK to Add :"+"\n"+"College Name: "+this.clg.collegeName+"\n"+"College Rank: "+this.clg.collegeRank+"\n"+"College Type : "+this.clg.collegeType);
    console.log(data);
    this.clg.collegeName="";
  this.clg.collegeRank=0;
  this.clg.collegeType="";
  this.router.navigate(['/college'])
  })
}
//student
createStudent(){
  this.homeService.createStudentService(this.student).subscribe((data)=>{
    alert("Are you OK to Add :"+"\nStudent Name : "+this.student.StudentName+"\nStudent Email : "+this.student.studentEmail+"\nStudent Department : "+this.student.studentDepartment+"\nStudent Age: "+this.student.studentAge+"\nStudent Phone : "+this.student.studentPhone+"\nStudent Fees: "+this.student.studentFees);
console.log(data);
this.student.StudentName="";
this.student.studentDepartment="";
this.student.studentEmail="";
this.student.studentAge=0;
this.student.studentPhone="";
this.student.studentFees=0;
this.router.navigate(['/student']);
  })
}

//teacher
getTeacher(){
  this.homeService.getTeacherService().subscribe((data)=>{
    console.log(data);
    this.teacherArray=data;
  })
}
createTeacher(){
  this.homeService.createTeacherService(this.teacher).subscribe((data)=>{
    alert("Are You OK to Add : "+"\nTeacher Name: "+this.teacher.teacherName+"\nTeacher Subject : "+this.teacher.teacherSubjet+"\nTeacher Salary : "+this.teacher.teacherSalary);
    console.log(data);
    this.teacher.teacherName="";
  this.teacher.teacherSubjet="";
  this.teacher.teacherSalary=0;
  this.router.navigate(['/teacher'])
  })
}
}
